using Encurtador.Data.Repositories.Interfaces;
using Encurtador.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Encurtador.Data.Repositories
{
    public class EncurtarRepository : RepositoryBase<Encurtado, int>, IEncurtarRepository
    {
        public EncurtarRepository(EncurtadorContext context) : base(context)
        {
        }

        public Task<Encurtado?> GetByUrlEncurtadaAsync(string urlEncurtada, CancellationToken cancellationToken)
        {
           return _dataset.Where(d => d.UrlEncurtada == urlEncurtada).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
