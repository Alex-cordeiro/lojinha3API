namespace Lojinha3API.Models
{
    public class JogoDesenvolvedora
    {
        public int Id { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
        public int DesenvolvedoraId { get; set; }
        public Desenvolvedora Desenvolvedora { get; set; }
    }
}
