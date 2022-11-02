using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Access.Relations;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lojinha3.Domain.Model.Navigation
{
    public class Menu : BaseEntity
    {
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Icone { get; set; }
        public int CategoriaAcessoId { get; set; }
        public CategoriaAcesso CategoriaAcesso { get; set; }

        [JsonIgnore]
        public List<PermissaoMenuUsuario> PermissaoMenuUsuarios { get; set; }
    }
}
