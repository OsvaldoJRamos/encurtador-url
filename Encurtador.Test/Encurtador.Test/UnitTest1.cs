using Encurtador.Domain.Dtos.Request;
using Encurtador.Service;

namespace Encurtador.Test
{
    public class UnitTest1
    {
        private readonly IEncurtarService _encurtarService;

        public UnitTest1(IEncurtarService encurtarService)
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