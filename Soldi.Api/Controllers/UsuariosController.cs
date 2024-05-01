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
    public class UsuariosController : ControllerBase
    {
        private readonly ICommandHandler<UsuarioAdicionarCommand> _adicionar;
        private readonly ICommandHandler<UsuarioAtualizarCommand> _atualizar;
        private readonly IUsuarioQueryHandler _query;

        public UsuariosController(ICommandHandler<UsuarioAdicionarCommand> adicionar,
            IUsuarioQueryHandler query, ICommandHandler<UsuarioAtualizarCommand> atualizar)
        {
            _adicionar = adicionar;
            _query = query;
            _atualizar = atualizar;
        }


        // GET: api/<UsuariosController>
        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            var result =await _query.GetAll();

            if (result.Success)
            {
                return Ok(result.t);
            }
            return BadRequest(result.Message);
        }

        // GET: api/<UsuariosController>
        /*[HttpGet("Nome/{nome}")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetByName(string nome)
        {
            var result = await _query.GetByExpression(UsuarioQuery.GetByName(nome));

            if (result.Success)
            {
                return Ok(result.t);
            }
            return BadRequest(result.Message);
        }*/

        // GET api/<UsuariosController>/5
        [HttpGet("Id/{id:guid}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(Guid id)
        {
            var result = await _query.GetById(id);

            if (result.Success)
            {
                return Ok(result.t);
            }
            return BadRequest(result.Message);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioAdicionarCommand Usuario)
        {
          var result= await  _adicionar.Handle(Usuario); 

            return result.Success? Created():BadRequest(result.Message);

        }

        // PUT api/<UsuariosController>/5
        [HttpPut]
        public async Task<ActionResult> Put( [FromBody] UsuarioAtualizarCommand Usuario)
        {
            var result = await _atualizar.Handle(Usuario);

            return result.Success ? Created() : BadRequest(result.Message);

        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
