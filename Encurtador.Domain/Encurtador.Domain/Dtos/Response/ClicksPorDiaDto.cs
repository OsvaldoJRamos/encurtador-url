namespace Encurtador.Domain.Dtos.Response
{
    public class ClicksPorDiaDto
    {
        public int Mes { get; set; }
        public List<ClickDto> Clicks { get; set; }
    }
}
