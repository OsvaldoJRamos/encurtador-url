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
        [Route("urlOriginal")]
        public async Task<IActionResult> GetUrlOriginalAsync(string urlEncurtada, CancellationToken cancellationToken)
        {
            try
            {
                var urlOriginal = await _encurtarService.GetUrlOriginalAsync(urlEncurtada, cancellationToken);

                _encurtarService.AdicionarClickAsync(urlEncurtada, cancellationToken);

                return Ok(urlOriginal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
