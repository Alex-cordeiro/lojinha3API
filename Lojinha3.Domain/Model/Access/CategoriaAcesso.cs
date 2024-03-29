﻿using Lojinha3.Domain.Model.Access.Relations;
using Lojinha3.Domain.Model.Navigation;
using System.Collections.Generic;

namespace Lojinha3.Domain.Model.Access
{
    public class CategoriaAcesso : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public List<CategoriaMenuUsuario> CategoriaMenuUsuario { get; set; }
        public List<Menu> Menu { get; set; }
    }
}
