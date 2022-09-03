using Lojinha3.Domain.Model;

namespace Lojinha3.Domain.Model
{
    public class JogoDesenvolvedora : BaseEntity
    {
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
        public int DesenvolvedoraId { get; set; }
        public Desenvolvedora Desenvolvedora { get; set; }
    }
}
