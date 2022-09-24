using Lojinha3.Domain.Model.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha3.Business.Interfaces
{
    public interface IPermissaoCategoriaMenuUsuarioBusiness
    {
        public PermissaoCategoriaMenuUsuario Create(PermissaoCategoriaMenuUsuario permissaoCategoriaMenuUsuario);
        public PermissaoCategoriaMenuUsuario FindByID(long id);
        List<PermissaoCategoriaMenuUsuario> FindAll();
        PermissaoCategoriaMenuUsuario Update(PermissaoCategoriaMenuUsuario permissaoCategoriaMenuUsuario);
        bool Delete(int id);
    }
}
