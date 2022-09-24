using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Dtos;
using System.Collections.Generic;

namespace Lojinha3.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        public Usuario Create(Usuario usuario);
        public Usuario FindByID(long id);
        List<UsuarioDto> FindAll();
        Usuario Update(Usuario usuario);
        bool Delete(int id);
    }
}
