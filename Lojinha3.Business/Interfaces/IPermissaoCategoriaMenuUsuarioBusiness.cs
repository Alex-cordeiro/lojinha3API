using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Access.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha3.Business.Interfaces
{
    public interface IPermissaoUsuarioBusiness
    {
        public PermissaoUsuario Create(PermissaoUsuario permissaoCategoriaMenuUsuario);
        public PermissaoUsuario FindByID(long id);
        List<PermissaoUsuario> FindAll();
        PermissaoUsuario Update(PermissaoUsuario permissaoCategoriaMenuUsuario);
        bool Delete(int id);
    }
}
