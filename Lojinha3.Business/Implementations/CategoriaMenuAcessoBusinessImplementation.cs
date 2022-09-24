using Lojinha3.Business.Interfaces;
using Lojinha3.Data.Repository.Generic;
using Lojinha3.Domain.Model.Access;
using Lojinha3API.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha3.Business.Implementations
{
    public class CategoriaMenuAcessoBusinessImplementation : ICategoriaMenuAcessoBussiness
    {
        private readonly IRepository<CategoriaMenuAcesso> _repository;

        private readonly LojinhaContext _lojinhaContext;

        public CategoriaMenuAcessoBusinessImplementation(IRepository<CategoriaMenuAcesso> repository, LojinhaContext context)
        {
            _repository = repository;
            _lojinhaContext = context;
        }

        public CategoriaMenuAcesso Create(CategoriaMenuAcesso categoriaMenuAcesso)
        {
            return _repository.Create(categoriaMenuAcesso);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<CategoriaMenuAcesso> FindAll()
        {
            return _repository.FindAll();
        }

        public CategoriaMenuAcesso FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public CategoriaMenuAcesso Update(CategoriaMenuAcesso categoriaMenuAcesso)
        {
            return _repository.Update(categoriaMenuAcesso);
        }
    }
}
