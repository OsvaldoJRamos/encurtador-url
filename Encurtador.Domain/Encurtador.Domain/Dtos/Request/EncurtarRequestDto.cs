namespace Encurtador.Domain.Dtos.Request
{
    public class EncurtarRequestDto
    {
        public string UrlOriginal { get; set; }

        public EncurtarRequestDto(string urlOriginal)
        {
            UrlOriginal = urlOriginal;
        }
    }
}
