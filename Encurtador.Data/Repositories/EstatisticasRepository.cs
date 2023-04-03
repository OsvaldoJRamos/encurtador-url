using Encurtador.Data.Repositories.Interfaces;
using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Dtos.Response;
using Encurtador.Domain.Entities;
using LinqKit;
using System.Linq.Expressions;

namespace Encurtador.Data.Repositories
{
    public class EstatisticasRepository : RepositoryBase<Click, int>, IEstatisticasRepository
    {
        public EstatisticasRepository(EncurtadorContext context) : base(context)
        {
        }

        public IQueryable<Click> GetClicsAsync(int? dia = null, int? mes = null, int? ano = null, string? urlEncurtada = null)
        {
            Expression<Func<Click, bool>> filterExpression = PredicateBuilder.New<Click>(true);
            if (dia.HasValue) filterExpression = filterExpression.And(x => x.Data.Day == dia);
            if (mes.HasValue) filterExpression = filterExpression.And(x => x.Data.Month == mes);
            if (ano.HasValue) filterExpression = filterExpression.And(x => x.Data.Year == ano);
            if (!string.IsNullOrEmpty(urlEncurtada)) filterExpression = filterExpression.And(x => x.Encurtado.UrlEncurtada == urlEncurtada);

            return _dataset.Where(filterExpression);
        }
    }
}
