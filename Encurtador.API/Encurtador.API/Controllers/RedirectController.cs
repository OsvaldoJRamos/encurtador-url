using Encurtador.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Encurtador.API.Controllers
{
    public class RedirectController : BaseApiController
    {
        private readonly IEncurtarService _encurtarService;
        private readonly IConfiguration _configuration;

        public RedirectController(IEncurtarService encurtarService, IConfiguration configuration)
        {
            _encurtarService = encurtarService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("{urlEncurtada}")]
        public async Task<RedirectResult?> RedirectToUrlOriginalAsync(string urlEncurtada, CancellationToken cancellationToken)
        {
            try
            {
                var encurtado = await _encurtarService.GetEncurtadoAsync(urlEncurtada, cancellationToken);

                if (encurtado is not null && !string.IsNullOrEmpty(encurtado.UrlEncurtada))
                {
                    await _encurtarService.AdicionarClickAsync(urlEncurtada, cancellationToken);
                    return Redirect(encurtado.UrlOriginal);
                }

                return Redirect($"{_configuration.GetValue<string>("EncurtadorSite")}/{urlEncurtada}");
            }
            catch (Exception ex)
            {
                return Redirect($"{_configuration.GetValue<string>("EncurtadorSite")}/{urlEncurtada}");
            }
        }
    }
}
