
namespace Lojinha3.Domain.Model.Relations
{
    public class JogoDesenvolvedora : BaseEntity
    {
        public int JogoId { get; set; }
        public int DesenvolvedoraId { get; set; }
        public Jogo Jogo { get; set; }
        public Desenvolvedora Desenvolvedora { get; set; }

    }
}
