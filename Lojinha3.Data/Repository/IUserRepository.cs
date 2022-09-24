using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Dtos;

namespace Lojinha3.Data.Repository
{
    public interface IUserRepository
    {
        Usuario ValidateCredentials(Usuario usuario);

        Usuario ValidateCredentials(string userName);

        bool RevokeToken(int id);

        Usuario RefreshUserInfo(Usuario usuario);
    }
}

