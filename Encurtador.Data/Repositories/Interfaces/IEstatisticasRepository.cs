using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Dtos.Response;
using Encurtador.Domain.Entities;

namespace Encurtador.Data.Repositories.Interfaces
{
    public interface IEstatisticasRepository : IRepositoryBase<Click, int>
    {
        IQueryable<Click> GetClicsAsync(int? dia = null, int? mes = null, int? ano = null, string? urlEncurtada = null);   
    }
}
