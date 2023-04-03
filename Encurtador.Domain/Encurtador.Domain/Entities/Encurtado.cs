using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encurtador.Domain.Entities
{
    public class Encurtado
    {
        public int Id { get; private set; }
        public string UrlOriginal { get; private set; }
        public string UrlEncurtada { get; private set; }
        public int NumeroCliques { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataExpiracao { get; private set; }
        public virtual ICollection<Click> Clicks { get; private set; } = new List<Click>();

        public Click AdicionarClick()
        {
            NumeroCliques++;

            var click = new Click();
            Clicks.Add(click);
            return click;
        }

        public Encurtado(string urlOriginal, int diasParaExpirar)
        {
            UrlOriginal = urlOriginal;
            DataCriacao = DateTime.Now;
            DataExpiracao = DateTime.Now.AddDays(diasParaExpirar);

            UrlEncurtada = GenerateRandom.Generate(6);
            NumeroCliques = 0;
        }

        protected Encurtado() { }
    }
}
