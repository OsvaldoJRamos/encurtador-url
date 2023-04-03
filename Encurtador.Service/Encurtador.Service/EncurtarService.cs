
using Encurtador.Data.Repositories.Interfaces;
using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Dtos.Response;
using Encurtador.Domain.Entities;
using Encurtador.Service.Interfaces;

namespace Encurtador.Service
{
    public class EncurtarService : IEncurtarService
    {
        private readonly IEncurtarRepository _encurtarRepository;
        private readonly IEstatisticasRepository _clickRepository;
        public EncurtarService(IEncurtarRepository encurtarRepository, IEstatisticasRepository clickRepository)
        {
            _encurtarRepository = encurtarRepository;
            _clickRepository = clickRepository;
        }

        public async Task<Encurtado> EncurtarAsync(EncurtarRequestDto request, CancellationToken cancellationToken)
        {
            var encurtado = new Encurtado(request.UrlOriginal, 365);

            await _encurtarRepository.AddAsync(encurtado, cancellationToken);
            await _encurtarRepository.SaveChangesAsync(cancellationToken);

            return encurtado;
        }

        public async Task<Encurtado> GetEncurtadoAsync(string urlEncurtada, CancellationToken cancellationToken)
        {
            var encurtado = await _encurtarRepository.GetByUrlEncurtadaAsync(urlEncurtada, cancellationToken);
            return encurtado;
        }

        public async Task AdicionarClickAsync(string urlEncurtada, CancellationToken cancellationToken)
        {
            var encurtado = await _encurtarRepository.GetByUrlEncurtadaAsync(urlEncurtada, cancellationToken);

            encurtado?.AdicionarClick();
            await _encurtarRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
