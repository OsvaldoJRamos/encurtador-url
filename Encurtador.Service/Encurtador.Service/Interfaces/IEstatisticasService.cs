using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Dtos.Response;

namespace Encurtador.Service.Interfaces
{
    public interface IEstatisticasService
    {
        Task<IEnumerable<ClickDto>> GetClicksPorHoraAsync(GetClicksPorHoraDto filter, CancellationToken cancellationToken);
        IEnumerable<ClicksPorDiaDto> GetClicksPorDiaAsync(GetClicksPorDiaDto filter, CancellationToken cancellationToken);
        Task<IEnumerable<ClickDto>> GetClicksPorMesAsync(GetClicksPorMesDto filter, CancellationToken cancellationToken);
    }
}
