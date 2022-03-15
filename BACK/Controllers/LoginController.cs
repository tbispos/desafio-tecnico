using Domain.DTOs;
using Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACK.Controllers
{
    //[Route("api/[controller]")] // ROTA PADRÃO REST
    [Route("[controller]")]       // ALTERADO DO PADRÃO REST PARA FICAR IGUAL AS CHAMADA DO FRONT EXISTENTE
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(
            ILoginService loginService
            )
        {
            this.loginService = loginService;
        }

        /// <summary>
        /// Faz login e gera o token
        /// </summary>
        /// <param name="LoginDto"> Dados de login</param>
        /// <returns> string com o token gerado</returns>
        /// <response code="200">Retorna o token</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status200OK, "token", typeof(string))]
        public IActionResult Login([FromBody] LoginDto login)
        {
            TokenDto r = loginService.ValidarLogin(login);

            if (r.authenticated == false)
                return StatusCode(401);
            else
                return StatusCode(200, r.token);
        }
    }
}
