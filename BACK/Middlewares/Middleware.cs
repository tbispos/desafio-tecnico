using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACK.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            bool possuiAcesso = this.VerificaToken(httpContext); //Verifica se o token é valido ou se está na rota /login

            if (!possuiAcesso)
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync("Status401Unauthorized");
            }
            else 
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync(ex.Message);
                }
            }
        }

        private bool VerificaToken(HttpContext httpContext)
        {
            try
            {
                HttpRequest req = httpContext.Request;

                if (req.Path.ToString().StartsWith("/login")) // Rota de Login permite acessar sem token
                    return true;

                string bearerToken = req.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString(); // Pega a key Authorization 
                
                if (String.IsNullOrEmpty(bearerToken)) // token vazio já bloqueia
                    return false;

                //Verifica se o token é válido
                string[] bearerSplited = bearerToken.Split(' ');
                bearerToken = bearerSplited.Count() > 1 ? bearerSplited[1] : bearerSplited[0];
                System.IdentityModel.Tokens.Jwt.JwtSecurityToken tokenInfo = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().ReadJwtToken(bearerToken);

                // Se conseguiu ler o token, ele é válido
                // Seria ideal gravar em cache o usuário e verificar sempre se o usuário logado é o dono do cache

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
