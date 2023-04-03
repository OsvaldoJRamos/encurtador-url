using Encurtador.Domain.Entities;

namespace Encurtador.Data.Repositories.Interfaces
{
    public interface IEncurtarRepository : IRepositoryBase<Encurtado, int>
    {
        Task<Encurtado?> GetByUrlEncurtadaAsync(string urlEncurtada, CancellationToken cancellationToken);
    }
}
