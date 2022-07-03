namespace Lojinha3API.Models
{
    public class EstoqueJogos
    {
        public int Id { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
        public int QteJogo { get; set; }
    }
}
