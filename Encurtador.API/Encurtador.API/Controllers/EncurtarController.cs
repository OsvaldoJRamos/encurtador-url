using Encurtador.Domain.Dtos.Request;
using Encurtador.Service;
using Microsoft.AspNetCore.Mvc;

namespace Encurtador.API.Controllers
{
    public class EncurtarController : BaseApiController
    {
        private readonly IEncurtarService _encurtarService;

        public EncurtarController(IEncurtarService encurtarService)
        {
            _encurtarService = encurtarService;

        }

        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> CreateAsync([FromBody] EncurtarRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var urlEncurtada = await _encurtarService.EncurtarAsync(request, cancellationToken);
                return Ok(urlEncurtada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Encurtado")]
        public async Task<IActionResult> GetEncurtadoAsync(string urlEncurtada, CancellationToken cancellationToken)
        {
            try
            {
                var encurtado = await _encurtarService.GetEncurtadoAsync(urlEncurtada, cancellationToken);

                if (encurtado is null)
                {
                    return BadRequest(new { mensagem = "Não encontrado!" });
                }

                return Ok(encurtado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
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
                    return Redirect(encurtado.UrlEncurtada);
                }

                return Redirect($"https://encurtador.app/{urlEncurtada}");
            }
            catch (Exception ex)
            {
                return Redirect($"https://encurtador.app/{urlEncurtada}");
            }
        }
    }
}
