using Lojinha3.Domain.Model.Navigation;

namespace Lojinha3.Domain.Model.Access
{
    public class PermissaoMenuUsuario : BaseEntity
    {
        public int MenuId { get; set; }
        public int UsuarioId { get; set; }
        public Menu Menu { get; set; }
        public Usuario Usuario { get; set; }
    }
}
