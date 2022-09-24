using System.Collections.Generic;

namespace Lojinha3.Domain.Model.Access
{
    public class CategoriaMenuAcesso : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public List<PermissaoCategoriaMenuUsuario> PermissaoCategoriaMenuUsuarios { get; set; }


    }
}
