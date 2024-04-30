using Microsoft.AspNetCore.Mvc;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Core.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Soldi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartoesController : ControllerBase
    {
        private readonly ICommandHandler<CartaoAdicionarCommand> _adicionar;
        private readonly IQueryHandler<CartaoDTO> _query;

        public CartoesController(ICommandHandler<CartaoAdicionarCommand> adicionar, IQueryHandler<CartaoDTO> query)
        {
            _adicionar = adicionar;
            _query = query;
        }


        // GET: api/<CartoesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartaoDTO>>> Get()
        {
            var result =await _query.GetAll();

            if (result.Success)
            {
                return Ok(result.t);
            }
            return BadRequest(result.Message);
        }

        // GET api/<CartoesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartoesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CartaoAdicionarCommand cartao)
        {
          var result= await  _adicionar.Handle(cartao); 

            return result.Success? Created():BadRequest(result.Message);

        }

        // PUT api/<CartoesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartoesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
