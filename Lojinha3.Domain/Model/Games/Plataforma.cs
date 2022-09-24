using Lojinha3.Domain.Model.Relations;
using System.Collections.Generic;

namespace Lojinha3.Domain.Model.Games
{
    public class Plataforma : BaseEntity
    {
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public List<JogoPlataforma> JogosPlataformas { get; set; }
    }
}
