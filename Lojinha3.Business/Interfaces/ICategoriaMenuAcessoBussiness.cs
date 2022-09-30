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
        public CategoriaAcesso Create(CategoriaAcesso categoriaMenuAcesso);
        public CategoriaAcesso FindByID(long id);
        List<CategoriaAcesso> FindAll();
        CategoriaAcesso Update(CategoriaAcesso categoriaMenuAcesso);
        bool Delete(int id);
    }
}
