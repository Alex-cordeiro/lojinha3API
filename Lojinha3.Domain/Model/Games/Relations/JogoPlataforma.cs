using Lojinha3.Domain.Model.Games;
using Lojinha3.Domain.Model.Inventory;
using System.Collections.Generic;

namespace Lojinha3.Domain.Model.Relations
{
    public class JogoPlataforma : BaseEntity
    {
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
        public int PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }
        public List<Estoque> Estoque { get; set; }
    }
}
