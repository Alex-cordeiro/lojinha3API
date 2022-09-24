using Lojinha3.Business.Interfaces;
using Lojinha3.Data.Repository.Generic;
using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Dtos;
using Lojinha3.Helpers.Cripto;
using System.Collections.Generic;

namespace Lojinha3.Business.Implementations
{
    public class UsuarioBusinessImplementation : IUsuarioBusiness
    {
        private readonly IRepository<Usuario> _repository;
        

        public UsuarioBusinessImplementation(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        public Usuario Create(Usuario usuario)
        {
            usuario.Senha = Encript.ComputeHash(usuario.Senha);
            return _repository.Create(usuario);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<UsuarioDto> FindAll()
        {
            List <UsuarioDto> usuariosRetorno = new List<UsuarioDto>();
             var usuarios = _repository.FindAll();

            foreach (var usuario in usuarios)
            {
                usuariosRetorno.Add( new UsuarioDto(){ Id = usuario.Id, Nome = usuario.Nome, UserName = usuario.UserName});
            }

            return usuariosRetorno;
        }

        public Usuario FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Usuario Update(Usuario usuario)
        {
            return _repository.Update(usuario);
        }
    }
}
