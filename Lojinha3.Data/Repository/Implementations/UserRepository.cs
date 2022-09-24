using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Dtos;
using Lojinha3.Helpers.Cripto;
using Lojinha3API.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Lojinha3.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly LojinhaContext _context;

        public UserRepository(LojinhaContext context)
        {
            _context = context;
        }

        public Usuario RefreshUserInfo(Usuario usuario)
        {
            if (_context.Usuarios.Any(u => u.Id.Equals(usuario.Id))) return null;

            var result = _context.Usuarios.SingleOrDefault(u => u.Id.Equals(usuario.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(usuario);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return result;
        }

        public bool RevokeToken(int id)
        {
            var user = _context.Usuarios.SingleOrDefault(u => (u.Id == id));
            if (user is null) 
                return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        public Usuario ValidateCredentials(Usuario usuario)
        {
            var password = Encript.ComputeHash(usuario.Senha);
            return _context.Usuarios.FirstOrDefault(x => (x.UserName == usuario.UserName && x.Senha == password));
        }

        public Usuario ValidateCredentials(string userName)
        {
            return _context.Usuarios.SingleOrDefault(u => (u.UserName == userName));
        }
     }   
}
