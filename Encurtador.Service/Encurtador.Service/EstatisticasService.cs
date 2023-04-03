using Encurtador.Data.Repositories;
using Encurtador.Data.Repositories.Interfaces;
using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Dtos.Response;
using Encurtador.Service.Interfaces;

namespace Encurtador.Service
{
    public class EstatisticasService : IEstatisticasService
    {
        private readonly IEstatisticasRepository _estatisticaRepository;
        public EstatisticasService(IEstatisticasRepository estatisticaRepository)
        {
            _estatisticaRepository = estatisticaRepository;
        }
        public Task<IEnumerable<ClickDto>> GetClicksPorHoraAsync(GetClicksPorHoraDto filter, CancellationToken cancellationToken)
        {
            return _estatisticaRepository.GetClicksPorHoraAsync(filter, cancellationToken);
        }

        public Task<IEnumerable<ClickDto>> GetClicksPorDiaAsync(GetClicksPorDiaDto filter, CancellationToken cancellationToken)
        {
            return _estatisticaRepository.GetClicksPorDiaAsync(filter, cancellationToken);
        }

        public Task<IEnumerable<ClickDto>> GetClicksPorMesAsync(GetClicksPorMesDto filter, CancellationToken cancellationToken)
        {
            return _estatisticaRepository.GetClicksPorMesAsync(filter, cancellationToken);
        }
    }
}
