using AutoMapper;
using Domain.DTOs;
using Domain.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;

namespace BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService service;
        private readonly IMapper mapper;

        public CardsController(ICardService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// Retorna uma Lista de Cards
        /// </summary>
        /// <returns>Uma lista de objeto de CardDto </returns>
        /// <response code="200">Retorna o item solicitado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [SwaggerResponse(StatusCodes.Status200OK, "List<CardDto>", typeof(List<CardDto>))]
        public IActionResult GetAll()
        {
            var cards    = service.GetAll();
            var cardsDto = mapper.Map<List<CardDto>>(cards);

            return Ok(cardsDto);
        }
    }
}
