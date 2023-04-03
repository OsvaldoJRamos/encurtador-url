namespace Encurtador.Domain.Dtos.Request
{
    public class GetClicksPorDiaDto : GetClicksDto
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}
