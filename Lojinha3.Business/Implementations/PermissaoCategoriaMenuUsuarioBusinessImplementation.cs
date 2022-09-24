using Lojinha3.Business.Interfaces;
using Lojinha3.Data.Repository.Generic;
using Lojinha3.Domain.Model.Access;
using Lojinha3API.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lojinha3.Business.Implementations
{
    public class PermissaoCategoriaMenuUsuarioBusinessImplementation : IPermissaoCategoriaMenuUsuarioBusiness
    {
        private readonly IRepository<PermissaoCategoriaMenuUsuario> _repository;
        private readonly LojinhaContext _lojinhaContext;

        public PermissaoCategoriaMenuUsuarioBusinessImplementation(IRepository<PermissaoCategoriaMenuUsuario> repository, LojinhaContext lojinhaContext)
        {
            _repository = repository;
            _lojinhaContext = lojinhaContext;
        }


        public PermissaoCategoriaMenuUsuario Create(PermissaoCategoriaMenuUsuario permissaoCategoriaMenuUsuario)
        {
            return _repository.Create(permissaoCategoriaMenuUsuario);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<PermissaoCategoriaMenuUsuario> FindAll()
        {
            return _repository.FindAll();
        }

        public PermissaoCategoriaMenuUsuario FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public PermissaoCategoriaMenuUsuario Update(PermissaoCategoriaMenuUsuario permissaoCategoriaMenuUsuario)
        {
            return _repository.Update(permissaoCategoriaMenuUsuario);
        }

        public List<PermissaoCategoriaMenuUsuario> FindByUserPermission(int id)
        {
            var permissoes =  _lojinhaContext.PermissaoCategoriaMenuUsuarios.Where(pcmu => pcmu.UsuarioId.Equals(id))
                                                                 .Include(p => p.CategoriaMenuAcesso)
                                                                 .ToList();

            return permissoes;
        }
    }
}
