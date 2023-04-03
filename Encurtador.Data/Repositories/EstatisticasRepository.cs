using Encurtador.Data.Repositories.Interfaces;
using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Dtos.Response;
using Encurtador.Domain.Entities;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Encurtador.Data.Repositories
{
    public class EstatisticasRepository : RepositoryBase<Click, int>, IEstatisticasRepository
    {
        public EstatisticasRepository(EncurtadorContext context) : base(context)
        {
        }

        private IQueryable<Click> GetClicsAsync(int? dia = null, int? mes = null, int? ano = null, string? urlEncurtada = null)
        {
            Expression<Func<Click, bool>> filterExpression = PredicateBuilder.New<Click>(true);
            if (dia.HasValue) filterExpression = filterExpression.And(x => x.Data.Day >= dia);
            if (mes.HasValue) filterExpression = filterExpression.And(x => x.Data.Month >= mes);
            if (ano.HasValue) filterExpression = filterExpression.And(x => x.Data.Year <= ano);
            if (!string.IsNullOrEmpty(urlEncurtada)) filterExpression = filterExpression.And(x => x.Encurtado.UrlEncurtada == urlEncurtada);

            return _dataset.Where(filterExpression);
        }

        public async Task<IEnumerable<ClickDto>> GetClicksPorHoraAsync(GetClicksPorHoraDto filter, CancellationToken cancellationToken)
        {
            var clicks = GetClicsAsync(filter.Dia, filter.Mes, filter.Ano, filter.UrlEncurtada);
            var agrupado = clicks.GroupBy(x => x.Data.Hour);

            return agrupado.Select(a => new ClickDto { UnidadeAgrupamento = a.Key.ToString(), Quantidade = a.Count() }).AsEnumerable();
        }

        public async Task<IEnumerable<ClickDto>> GetClicksPorDiaAsync(GetClicksPorDiaDto filter, CancellationToken cancellationToken)
        {
            var clicks = GetClicsAsync(mes: filter.Mes, ano: filter.Ano, urlEncurtada: filter.UrlEncurtada);
            var agrupado = clicks.GroupBy(x => x.Data.Day);

            return agrupado.Select(a => new ClickDto { UnidadeAgrupamento = a.Key.ToString(), Quantidade = a.Count() }).AsEnumerable();
        }

        public async Task<IEnumerable<ClickDto>> GetClicksPorMesAsync(GetClicksPorMesDto filter, CancellationToken cancellationToken)
        {
            var clicks = GetClicsAsync(ano: filter.Ano, urlEncurtada: filter.UrlEncurtada);
            var agrupado = clicks.GroupBy(x => x.Data.Month);

            return agrupado.Select(a => new ClickDto { UnidadeAgrupamento = a.Key.ToString(), Quantidade = a.Count() }).AsEnumerable();
        }
    }
}
