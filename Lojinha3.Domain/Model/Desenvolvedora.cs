using Lojinha3.Domain.Model;
using Lojinha3.Domain.Model.Relations;
using System.Collections.Generic;

namespace Lojinha3.Domain.Model
{
    public class Desenvolvedora : BaseEntity
    {
        public string Nome { get; set; }
        public string Pais { get; set; }
        public Jogo Jogo { get; set; }
        public List<JogoDesenvolvedora> JogoDesenvolvedoras { get; set; }
    }
}
