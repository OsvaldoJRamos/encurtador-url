using Encurtador.Domain.Dtos.Request;
using Encurtador.Service.Interfaces;

namespace Encurtador.Test
{
    public class EncurtarTest
    {
        private readonly IEncurtarService _encurtarService;

        public EncurtarTest(IEncurtarService encurtarService)
        {
            _encurtarService = encurtarService;
        }

        [Fact]
        public async Task DeveEncurtarComSucessoComLinkValido()
        {
            var link = "https://www.amazon.com.br/Entendendo-Algoritmos-Ilustrado-Programadores-Curiosos/dp/8575225634#customerReviews";
            var encurtado = await _encurtarService.EncurtarAsync(new EncurtarRequestDto(link), CancellationToken.None);
            Assert.NotNull(encurtado.UrlEncurtada);
        }
    }
}