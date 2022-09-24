using Lojinha3.Domain.Model.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha3.Business.Interfaces
{
    public interface ICategoriaMenuAcessoBussiness
    {
        public CategoriaMenuAcesso Create(CategoriaMenuAcesso categoriaMenuAcesso);
        public CategoriaMenuAcesso FindByID(long id);
        List<CategoriaMenuAcesso> FindAll();
        CategoriaMenuAcesso Update(CategoriaMenuAcesso categoriaMenuAcesso);
        bool Delete(int id);
    }
}
