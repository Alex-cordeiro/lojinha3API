using Lojinha3.Business.Interfaces;
using Lojinha3.Data.Migrations;
using Lojinha3.Data.Repository.Generic;
using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Access.Relations;
using Lojinha3.Domain.Model.Navigation;
using Lojinha3API.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lojinha3.Business.Implementations
{
    public class PermissaoMenuUsuarioBusinessImplementation : IPermissaoMenuUsuarioBusiness
    {
        private readonly IRepository<PermissaoMenuUsuario> _repository;
        private readonly LojinhaContext _lojinhaContext;

        public PermissaoMenuUsuarioBusinessImplementation(IRepository<PermissaoMenuUsuario> repository, LojinhaContext lojinhaContext)
        {
            _repository = repository;
            _lojinhaContext = lojinhaContext;
        }

        public PermissaoMenuUsuario Create(PermissaoMenuUsuario permissaoCategoriaMenuUsuario)
        {
            return _repository.Create(permissaoCategoriaMenuUsuario);

        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<PermissaoMenuUsuario> FindAll()
        {
            return _repository.FindAll();
        }

        public PermissaoMenuUsuario FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public PermissaoMenuUsuario Update(PermissaoMenuUsuario permissaoCategoriaMenuUsuario)
        {
            return _repository.Update(permissaoCategoriaMenuUsuario);
        }

        public List<PermissaoMenuUsuario> FindByUserPermission(int id)
        {
            var menuspermitidos = _lojinhaContext.PermissaoMenuUsuarios
                                    .Where(x => x.UsuarioId.Equals(id))
                                    .Include(x => x.Menu)
                                    .Select(p => new PermissaoMenuUsuario
                                    {
                                        Menu = p.Menu
                                    })
                                    .ToList();
            return menuspermitidos;
        }
       
    }
}
