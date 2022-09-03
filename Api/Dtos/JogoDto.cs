using System.Collections.Generic;

namespace Lojinha3API.Models.Dtos
{
    public class JogoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AnoLancamento { get; set; }
        public int IdDesenvolvedora { get; set; }
        public int IdPlataforma { get; set; }
    }
}
