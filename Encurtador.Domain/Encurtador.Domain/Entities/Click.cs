using System.ComponentModel.DataAnnotations;

namespace Encurtador.Domain.Entities
{
    public class Click
    {
        public long Id { get; private set; }
        public DateTime Data { get; private set; }

        public Click(long encurtadoId)
        {
            Data = DateTime.Now;
        }

        protected Click() { }
    }
}
