
using Encurtador.Data.Repositories.Interfaces;
using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Entities;

namespace Encurtador.Service
{
    public class EncurtarService : IEncurtarService
    {
        private readonly IEncurtarRepository _encurtarRepository;
        public EncurtarService(IEncurtarRepository encurtarRepository)
        {
            _encurtarRepository = encurtarRepository;
        }

        public async Task<Encurtado> EncurtarAsync(EncurtarRequestDto request, CancellationToken cancellationToken)
        {
            var encurtado = new Encurtado(request.UrlOriginal, 365);

            await _encurtarRepository.AddAsync(encurtado, cancellationToken);
            await _encurtarRepository.SaveChangesAsync(cancellationToken);

            return encurtado;
        }

        public async Task<string?> GetUrlOriginalAsync(string urlEncurtada, CancellationToken cancellationToken)
        {
            var encurtado = await _encurtarRepository.GetByUrlEncurtadaAsync(urlEncurtada, cancellationToken);
            return encurtado?.UrlOriginal;
        }

        public async Task AdicionarClickAsync(string urlEncurtada, CancellationToken cancellationToken)
        {
            var encurtado = await _encurtarRepository.GetByUrlEncurtadaAsync(urlEncurtada, cancellationToken);

            encurtado?.AdicionarClick();
            await _encurtarRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
