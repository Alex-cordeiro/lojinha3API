using Lojinha3.Business.Interfaces;
using Lojinha3.Data.Repository.Generic;
using Lojinha3.Domain.Model.Access.Relations;
using Lojinha3API.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lojinha3.Business.Implementations
{
    public class PermissaoUsuarioBusinessImplementation : IPermissaoUsuarioBusiness
    {
        private readonly IRepository<PermissaoUsuario> _repository;
        private readonly LojinhaContext _lojinhaContext;

        public PermissaoUsuarioBusinessImplementation(IRepository<PermissaoUsuario> repository, LojinhaContext lojinhaContext)
        {
            _repository = repository;
            _lojinhaContext = lojinhaContext;
        }

        public PermissaoUsuario Create(PermissaoUsuario permissaoCategoriaMenuUsuario)
        {
            return _repository.Create(permissaoCategoriaMenuUsuario);

        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<PermissaoUsuario> FindAll()
        {
            return _repository.FindAll();
        }

        public PermissaoUsuario FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public PermissaoUsuario Update(PermissaoUsuario permissaoCategoriaMenuUsuario)
        {
            return _repository.Update(permissaoCategoriaMenuUsuario);
        }

        public List<PermissaoUsuario> FindByUserPermission(int id)
        {
            var permissoes = _lojinhaContext.PermissaoUsuarios.Include(x => x.CategoriaAcesso)
                                                              .Include(x => x.Menu)
                                                              .Where(x => x.UsuarioId.Equals(id)).ToList();
            return permissoes;
        }
    }
}
