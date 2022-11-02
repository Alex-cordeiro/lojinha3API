namespace Lojinha3.Domain.Model.Access.Relations
{
    public class CategoriaMenuUsuario : BaseEntity
    {
        public int CategoriaAcessoId { get; set; }
        public int UsuarioId { get; set; }
        public CategoriaAcesso CategoriaAcesso { get; set; }
        public Usuario Usuario { get; set; }

    }
}
