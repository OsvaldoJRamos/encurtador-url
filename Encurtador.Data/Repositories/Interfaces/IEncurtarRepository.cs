using Encurtador.Domain.Entities;

namespace Encurtador.Data.Repositories.Interfaces
{
    public interface IEncurtarRepository : IRepositoryBase<Encurtado, Guid>
    {
        Task<Encurtado?> GetByUrlEncurtadaAsync(string urlEncurtada, CancellationToken cancellationToken);
    }
}
