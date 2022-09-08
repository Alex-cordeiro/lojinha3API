﻿using System.Collections.Generic;

namespace Lojinha3.Domain.Model.Access
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }
        public List<PermissaoMenuUsuario> PermissaoUsuarios { get; set; }

    }
}