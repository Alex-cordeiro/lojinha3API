using Lojinha3.Business.Interfaces;
using Lojinha3.Configurations;
using Lojinha3.Data.Repository;
using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Dtos;
using Lojinha3.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Lojinha3.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:MM:ss";
        private TokenConfiguration _tokenConfiguration;

        private IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration tokenConfiguration, IUserRepository repository, ITokenService tokenService)
        {
            _tokenConfiguration = tokenConfiguration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenDto ValidateCredentials(Usuario usuario)
        {
            var usuarioValido = _repository.ValidateCredentials(usuario);
            if (usuarioValido != null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuarioValido.UserName)

            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            usuarioValido.RefreshToken = refreshToken;
            usuarioValido.RefreshTokenExpiryTime = DateTime.Now.AddDays(_tokenConfiguration.DaysToExpiry);

            _repository.RefreshUserInfo(usuarioValido);

            DateTime createDateTime = DateTime.Now;

            DateTime expirationDate = createDateTime.AddMinutes(_tokenConfiguration.Minutes);


            return new TokenDto(
                true,
                createDateTime.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken);

        }

        public TokenDto ValidateCredentials(TokenDto token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var userName = principal.Identity.Name;

            var user = _repository.ValidateCredentials(userName);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _repository.RefreshUserInfo(user);


            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_tokenConfiguration.Minutes);

            return new TokenDto(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken);
        }

        public bool RevokeToken(int id)
        {
            return _repository.RevokeToken(id);
        }
    }
}
