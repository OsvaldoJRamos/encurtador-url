namespace Encurtador.Domain.Dtos.Request
{
    public class GetClicksPorHoraDto : GetClicksDto
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}
