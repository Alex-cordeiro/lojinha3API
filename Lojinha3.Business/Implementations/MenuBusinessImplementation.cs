using Lojinha3.Business.Interfaces;
using Lojinha3.Data.Repository.Generic;
using Lojinha3.Domain.Model.Navigation;
using System.Collections.Generic;

namespace Lojinha3.Business.Implementations
{
    public class MenuBusinessImplementation : IMenuBusiness
    {
        private readonly IRepository<Menu> _repository;

        public MenuBusinessImplementation(IRepository<Menu> repository)
        {
            _repository = repository;
        }

        public Menu Create(Menu menu)
        {
            return _repository.Create(menu);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<Menu> FindAll()
        {
            return _repository.FindAll();
        }

        public Menu FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Menu Update(Menu menu)
        {
            return _repository.Update(menu);
        }
    }
}
