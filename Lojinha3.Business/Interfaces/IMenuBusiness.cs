using Lojinha3.Domain.Model.Navigation;
using System.Collections.Generic;

namespace Lojinha3.Business.Interfaces
{
    public interface IMenuBusiness
    {
        public Menu Create(Menu menu);
        public Menu FindByID(long id);
        List<Menu> FindAll();
        Menu Update(Menu menu);
        bool Delete(int id);
    }
}
