using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Application.Usuarios.Consultar;

namespace TechChallenge.GameStore.WebApi.Usuarios.Consultar
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Usuário")]
    public class ConsultarUsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultarUsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Consulta todos usuários",
            Description = "Realiza a consulta de todos os usuários cadastrados"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ConsultarTodos()
        {
            var result = await _mediator.Send(new ConsultarTodosUsuariosQuery());

            if (!result.Sucesso)
                return NotFound(result.Erro);
            
            return Ok(result.Valor);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consulta usuário pelo ID",
            Description = "Realiza a consulta do usuário pelo ID cadastrado"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            var result = await _mediator.Send(new ConsultarUsuarioPorIdQuery { Id = id });
            
            if (!result.Sucesso)
                return NotFound(result.Erro);
            
            return Ok(result.Valor);
        }
        
    }
}
