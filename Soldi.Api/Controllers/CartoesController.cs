using Microsoft.AspNetCore.Mvc;
using Soldi.Application.Base;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Application.Queries;
using Soldi.Core.Base;
using Soldi.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Soldi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartoesController : ControllerBase
    {
        private readonly ICommandHandler<CartaoAdicionarCommand> _adicionar;
        private readonly ICommandHandler<CartaoAtualizarCommand> _atualizar;
        private readonly ICartaoQueryHandler _query;

        public CartoesController(ICommandHandler<CartaoAdicionarCommand> adicionar,
            ICartaoQueryHandler query, ICommandHandler<CartaoAtualizarCommand> atualizar)
        {
            _adicionar = adicionar;
            _query = query;
            _atualizar = atualizar;
        }


        // GET: api/<CartoesController>
        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<CartaoDTO>>> GetAll()
        {
            var result =await _query.GetAll();

            if (result.Success)
            {
                return Ok(result.t);
            }
            return BadRequest(result.Message);
        }

        // GET: api/<CartoesController>
        [HttpGet("ByName/{nome}")]
        public async Task<ActionResult<IEnumerable<CartaoDTO>>> GetByName(string nome)
        {
            var result = await _query.GetByExpression(CartaoQuery.GetByName(nome));

            if (result.Success)
            {
                return Ok(result.t);
            }
            return BadRequest(result.Message);
        }

        // GET api/<CartoesController>/5
        [HttpGet("ById/{id:guid}")]
        public async Task<ActionResult<CartaoDTO>> GetById(Guid id)
        {
            var result = await _query.GetById(id);

            if (result.Success)
            {
                return Ok(result.t);
            }
            return BadRequest(result.Message);
        }

        // POST api/<CartoesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CartaoAdicionarCommand cartao)
        {
          var result= await  _adicionar.Handle(cartao); 

            return result.Success? Created():BadRequest(result.Message);

        }

        // PUT api/<CartoesController>/5
        [HttpPut]
        public async Task<ActionResult> Put( [FromBody] CartaoAtualizarCommand cartao)
        {
            var result = await _atualizar.Handle(cartao);

            return result.Success ? Created() : BadRequest(result.Message);

        }

        // DELETE api/<CartoesController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
