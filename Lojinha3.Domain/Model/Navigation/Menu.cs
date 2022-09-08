using Lojinha3.Domain.Model.Access;
using System.Collections.Generic;

namespace Lojinha3.Domain.Model.Navigation
{
    public class Menu : BaseEntity
    {
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Icone { get; set; }
        public List<PermissaoMenuUsuario> PermissaoUsuarios { get; set; }
    }
}
