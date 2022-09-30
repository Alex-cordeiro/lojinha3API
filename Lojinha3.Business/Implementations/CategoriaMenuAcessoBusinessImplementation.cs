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
        private readonly IRepository<CategoriaAcesso> _repository;

        private readonly LojinhaContext _lojinhaContext;

        public CategoriaMenuAcessoBusinessImplementation(IRepository<CategoriaAcesso> repository, LojinhaContext context)
        {
            _repository = repository;
            _lojinhaContext = context;
        }

        public CategoriaAcesso Create(CategoriaAcesso categoriaMenuAcesso)
        {
            return _repository.Create(categoriaMenuAcesso);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<CategoriaAcesso> FindAll()
        {
            return _repository.FindAll();
        }

        public CategoriaAcesso FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public CategoriaAcesso Update(CategoriaAcesso categoriaMenuAcesso)
        {
            return _repository.Update(categoriaMenuAcesso);
        }
    }
}
