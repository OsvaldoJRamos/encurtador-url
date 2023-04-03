using Encurtador.Data.Repositories;
using Encurtador.Data.Repositories.Interfaces;
using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Dtos.Response;
using Encurtador.Service.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Encurtador.Service
{
    public class EstatisticasService : IEstatisticasService
    {
        private readonly IEstatisticasRepository _estatisticaRepository;
        public EstatisticasService(IEstatisticasRepository estatisticaRepository)
        {
            _estatisticaRepository = estatisticaRepository;
        }

        public async Task<IEnumerable<ClickDto>> GetClicksPorHoraAsync(GetClicksPorHoraDto filter, CancellationToken cancellationToken)
        {
            var clicks = _estatisticaRepository.GetClicsAsync(filter.Dia, filter.Mes, filter.Ano, filter.UrlEncurtada);
            var agrupado = clicks.GroupBy(x => x.Data.Hour);

            return agrupado.Select(a => new ClickDto { UnidadeAgrupamento = a.Key.ToString(), Quantidade = a.Count() }).AsEnumerable();
        }

        public IEnumerable<ClicksPorDiaDto> GetClicksPorDiaAsync(GetClicksPorDiaDto filter, CancellationToken cancellationToken)
        {
            for (int i = 1; i < 13; i++)
            {
                var mes = i;

                var clicksDoMes = _estatisticaRepository.GetClicsAsync(mes: mes, ano: filter.Ano, urlEncurtada: filter.UrlEncurtada);
                var grupoClicksDoMes = clicksDoMes.GroupBy(x => x.Data.Day);

                var dtoClicksDoMes = grupoClicksDoMes.Select(a => new ClickDto { UnidadeAgrupamento = a.Key.ToString(), Quantidade = a.Count() }).AsEnumerable();

                yield return new ClicksPorDiaDto { Mes = mes, Clicks = dtoClicksDoMes.ToList() };
            }
        }

        public async Task<IEnumerable<ClickDto>> GetClicksPorMesAsync(GetClicksPorMesDto filter, CancellationToken cancellationToken)
        {
            var clicks = _estatisticaRepository.GetClicsAsync(ano: filter.Ano, urlEncurtada: filter.UrlEncurtada);
            var agrupado = clicks.GroupBy(x => x.Data.Month);

            return agrupado.Select(a => new ClickDto { UnidadeAgrupamento = a.Key.ToString(), Quantidade = a.Count() }).AsEnumerable();
        }
    }
}
