using Lojinha3.Domain.Model.Navigation;

namespace Lojinha3.Domain.Model.Access.Relations
{
    public class PermissaoUsuario : BaseEntity
    {
        public int UsuarioId { get; set; }
        public int MenuId { get; set; }
        public int CategoriaAcessoId { get; set; }
        public Usuario Usuario { get; set; }
        public Menu Menu { get; set; }
        public CategoriaAcesso CategoriaAcesso { get; set; }
    }
}
