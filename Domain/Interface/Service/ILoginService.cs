using Domain.DTOs;
using Domain.Entidades;
using Domain.Login;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface ILoginService
    {
        //TokenDto GerarToken(SigningConfigurations signingConfigurations, LoginDto login);
        TokenDto ValidarLogin(LoginDto login);

    }
}
