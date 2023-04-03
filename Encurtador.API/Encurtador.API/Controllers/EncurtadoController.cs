using Encurtador.Domain.Dtos.Request;
using Encurtador.Domain.Entities;
using Encurtador.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Encurtador.API.Controllers
{
    public class EncurtadoController : BaseApiController
    {
        private readonly IEncurtarService _encurtarService;
        private readonly IConfiguration _configuration;

        public EncurtadoController(IEncurtarService encurtarService, IConfiguration configuration)
        {
            _encurtarService = encurtarService;
            _configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Encurtado), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(typeof(Encurtado), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Encurtado/{urlEncurtada}")]
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
    }
}
