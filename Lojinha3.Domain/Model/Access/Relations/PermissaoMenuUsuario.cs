using Lojinha3.Domain.Model.Navigation;

namespace Lojinha3.Domain.Model.Access.Relations
{
    public class PermissaoMenuUsuario : BaseEntity
    {
        public int UsuarioId { get; set; }
        public int MenuId { get; set; }
        public Usuario Usuario { get; set; }
        public Menu Menu { get; set; }
    }
}
