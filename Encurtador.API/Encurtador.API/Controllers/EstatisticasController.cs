using Encurtador.Domain.Dtos.Request;
using Encurtador.Service;
using Encurtador.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Encurtador.API.Controllers
{
    public class ClicksController : BaseApiController
    {
        private readonly IEstatisticasService _estatisticaService;
        private readonly IConfiguration _configuration;

        public ClicksController(
            IEstatisticasService estatisticaService, 
            IConfiguration configuration)
        {
            _estatisticaService = estatisticaService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("Clicks/Hora")]
        public async Task<IActionResult> GetClicksPorHoraAsync([FromQuery] GetClicksPorHoraDto filter, CancellationToken cancellationToken)
        {
            try
            {
                var clicks = await _estatisticaService.GetClicksPorHoraAsync(filter, cancellationToken);
                return Ok(clicks);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("Clicks/Dia")]
        public async Task<IActionResult> GetClicksPorDiaAsync([FromQuery] GetClicksPorDiaDto filter, CancellationToken cancellationToken)
        {
            try
            {
                var clicks = await _estatisticaService.GetClicksPorDiaAsync(filter, cancellationToken);
                return Ok(clicks);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("Clicks/Mes")]
        public async Task<IActionResult> GetClicksPorMesAsync([FromQuery] GetClicksPorMesDto filter, CancellationToken cancellationToken)
        {
            try
            {
                var clicks = await _estatisticaService.GetClicksPorMesAsync(filter, cancellationToken);
                return Ok(clicks);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
