using Domain.DTOs;
using Domain.Interface.Login;
using Domain.Interface.Service;
using Domain.Login;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Domain.Service
{
    public class LoginService : ILoginService
    {
        private readonly SigningConfigurations signingConfigurations;

        public LoginService(ISigningConfigurations signingConfigurations)
        {
            this.signingConfigurations = (SigningConfigurations)signingConfigurations;
        }
        private TokenDto GerarToken(LoginDto login)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(login.login),
                        new[] {
                        new Claim("login", login.login),
                        }
                    );

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer              = "Back",
                Audience            = "Bispo",
                SigningCredentials  = signingConfigurations.SigningCredentials,
                Subject             = identity,
                NotBefore           = DateTime.Now,
                Expires             = DateTime.Now.AddMinutes(5)
            }); ;

            var token = handler.WriteToken(securityToken);

            return new TokenDto
            {
                authenticated   = true,
                token           = token,
            };
        }

        public TokenDto ValidarLogin(LoginDto login)
        {
            TokenDto token = new TokenDto();

            if (login.login == "letscode" &&
                login.senha == "lets@123")
            {
                token = GerarToken(login);
            }

            return token;
        }
    }
}
