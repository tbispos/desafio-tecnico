using AutoMapper;
using Domain.DTOs;
using Domain.Entidades;
using Domain.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using static Domain.Util.Enums;

namespace BACK.Controllers
{
    //[Route("api/[controller]")]   // ROTA PADRÃO REST
    [Route("[controller]")]         // ALTERADO DO PADRÃO REST PARA FICAR IGUAL AS CHAMADA DO FRONT EXISTENTE
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _service;
        private readonly IMapper _mapper;

        public CardsController(ICardService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma Lista de Cards
        /// </summary>
        /// <returns>Uma lista de objeto de CardDto </returns>
        /// <response code="200">Retorna o item solicitado</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status200OK, "List<CardDto>", typeof(List<CardDto>))]
        public IActionResult GetAll()
        {
            var cards    = _service.GetAll();                    // Recupera a lista de cards do Banco
            var cardsDto = _mapper.Map<List<CardDto>>(cards);    // Mapeia a lista de Card para uma Dto para enviar pro front

            return StatusCode(200, cardsDto);
        }

        /// <summary>
        /// Adiciona um novo Card
        /// </summary>
        /// <param name="value"> Item a ser adicionado CardDto</param>
        /// <returns> Objeto CardDto salvo no banco com suas pk autogenerate, quando houver.</returns>
        /// <response code="201">Retorna o item salvo</response>
        /// <response code="400">BadRequest</response>
        /// <response code="405">Unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [SwaggerResponse(StatusCodes.Status201Created, "CardDto", typeof(CardDto))]
        public IActionResult Post(CardDto value)
        {
            if (value.id != 0)
                return StatusCode(400);                 // 400BadRequest

            var card = _mapper.Map<Card>(value);         // Recebe uma Dto do front e mapeia para entidade Card
            _service.Add(card);                          // Salva o card
            var cardDto = _mapper.Map<CardDto>(card);    // Mapeia o Card salvo para uma Dto com o id da pk gerado pelo banco e devolve para o front

            return StatusCode(201, cardDto);
        }


        /// <summary>
        /// Altera um Card existente
        /// </summary>
        /// <param name="value"> Item a ser alterado CardDto</param>
        /// <returns> Objeto CardDto alterado no banco</returns>
        /// <response code="200">Retorna o item alterado</response>
        /// <response code="400">BadRequest</response>
        /// <response code="404">NotFound</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, "CardDto", typeof(CardDto))]
        public IActionResult Put([FromRoute]int id, [FromBody]CardDto value)
        {
            if (id != value.id)
                return StatusCode(400);                 // 400BadRequest

            if (!_service.VerificarExiste(id))          // Valida existe
                return StatusCode(404);                 // 404NotFound

            var card = _mapper.Map<Card>(value);        // Recebe uma Dto do front e mapeia para entidade Card
            _service.Update(card);                      // Salva o card
            var cardDto = _mapper.Map<CardDto>(card);   // Mapeia o Card alterado para uma Dto e devolve para o front

            return StatusCode(200, cardDto);
        }

        /// <summary>
        /// Excluir um Card existente
        /// </summary>
        /// <param name="value"> Id do item a ser alterado Excluído</param>
        /// <returns> Objeto Lista de CardDto</returns>
        /// <response code="200">Retorna a Lista atualizada</response>
        /// <response code="404">NotFound</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, "List<CardDto>", typeof(List<CardDto>))]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_service.VerificarExiste(id))                  // Valida existe
                return StatusCode(404);                         // 404NotFound

            var card = _service.Get(id);                        // Recupera o Card a ser excluído
            _service.Delete(card);

            var cards = _service.GetAll();                      // Recupera a lista de cards do Banco
            var cardsDto = _mapper.Map<List<CardDto>>(cards);   // Mapeia a lista de Card para uma Dto para enviar pro front

            return StatusCode(200, cardsDto);
        }
    }
}
