using System.ComponentModel.DataAnnotations;

namespace Encurtador.Domain.Entities
{
    public class Click
    {
        public long Id { get; private set; }
        public DateTime Data { get; private set; }
        public virtual Encurtado Encurtado { get; set; }

        public Click()
        {
            Data = DateTime.Now;
        }
    }
}
