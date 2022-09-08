using Lojinha3.Domain.Model.Relations;
using System.Collections.Generic;

namespace Lojinha3.Domain.Model
{
    public class Jogo : BaseEntity
    {
        public string Titulo { get; set; }
        public int AnoLancamento { get; set; }
        public int DesenvolvedoraId { get; set; }
        public Desenvolvedora Desenvolvedora { get; set; }
        public List<JogoPlataforma> JogosPlataformas { get; set; }
        public List<JogoDesenvolvedora> JogoDesenvolvedoras { get; set; }
    }
}
