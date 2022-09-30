using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Navigation;

namespace Lojinha3.Domain.Model.Dtos
{
    public class PermissaoUsuarioDto
    {
        public int Id { get; set; }
        public CategoriaAcesso CategoriaAcesso { get; set; }
        public Menu menu { get; set; }

    }
}
