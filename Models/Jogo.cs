using System.Collections.Generic;

namespace Lojinha3API.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AnoLancamento { get; set; }
        public int DesenvolvedoraId { get; set; }
        public Desenvolvedora Desenvolvedora { get; set; }
        public int PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }
        

    }
}
