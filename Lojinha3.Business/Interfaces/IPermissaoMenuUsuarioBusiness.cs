using Lojinha3.Domain.Model.Access.Relations;
using System.Collections.Generic;

namespace Lojinha3.Business.Interfaces
{
    public interface IPermissaoMenuUsuarioBusiness
    {
        public PermissaoMenuUsuario Create(PermissaoMenuUsuario permissaoCategoriaMenuUsuario);
        public PermissaoMenuUsuario FindByID(long id);
        List<PermissaoMenuUsuario> FindAll();
        PermissaoMenuUsuario Update(PermissaoMenuUsuario permissaoCategoriaMenuUsuario);
        bool Delete(int id);
    }
}
