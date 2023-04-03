using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Dtos.Response;
using Encurtador.Domain.Entities;

namespace Encurtador.Data.Repositories.Interfaces
{
    public interface IEstatisticasRepository : IRepositoryBase<Click, int>
    {
        Task<IEnumerable<ClickDto>> GetClicksPorHoraAsync(GetClicksPorHoraDto filter, CancellationToken cancellationToken);
        Task<IEnumerable<ClickDto>> GetClicksPorDiaAsync(GetClicksPorDiaDto filter, CancellationToken cancellationToken);
        Task<IEnumerable<ClickDto>> GetClicksPorMesAsync(GetClicksPorMesDto filter, CancellationToken cancellationToken);      
    }
}
