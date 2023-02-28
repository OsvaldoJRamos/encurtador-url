using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Entities;

namespace Encurtador.Service
{
    public interface IEncurtarService
    {
        Task<Encurtado> EncurtarAsync(EncurtarRequestDto request, CancellationToken cancellationToken);
        Task<string?> GetUrlOriginalAsync(string urlEncurtada, CancellationToken cancellationToken);
        Task AdicionarClickAsync(string urlEncurtada, CancellationToken cancellationToken);
    }
}
