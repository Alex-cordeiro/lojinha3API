using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Dtos;

namespace Lojinha3.Business.Interfaces
{
    public interface ILoginBusiness
    {
        TokenDto ValidateCredentials(Usuario usuario);
        TokenDto ValidateCredentials(TokenDto token);
        bool RevokeToken(int id);
    }
}
