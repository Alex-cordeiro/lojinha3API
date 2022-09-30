using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Access.Relations;
using System.Collections.Generic;

namespace Lojinha3.Domain.Model.Navigation
{
    public class Menu : BaseEntity
    {
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Icone { get; set; }
        public List<PermissaoUsuario> PermissaoUsuarios { get; set; }
    }
}
