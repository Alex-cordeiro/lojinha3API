namespace Lojinha3.Domain.Model.Access
{
    public class PermissaoCategoriaMenuUsuario : BaseEntity
    {
        public int UsuarioId { get; set; }
        public int CategoriaMenuAcessoId { get; set; }
        public Usuario Usuario { get; set; }
        public CategoriaMenuAcesso CategoriaMenuAcesso { get; set; }
    }
}
