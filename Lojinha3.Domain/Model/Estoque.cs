using Lojinha3.Domain.Model;
using Lojinha3.Domain.Model.Relations;
using System.Collections.Generic;

namespace Lojinha3.Domain.Model
{
    public class Estoque : BaseEntity
    {
        public JogoPlataforma JogoPlataforma { get; set; }
        public int JogoPlataformaId { get; set; }
        public int QteJogoPorPlataforma { get; set; }
        public decimal Preco { get; set; }
    }
}
