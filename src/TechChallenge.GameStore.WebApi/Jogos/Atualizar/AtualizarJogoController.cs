using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using TechChallenge.GameStore.Application.Jogos.Atualizar;

namespace TechChallenge.GameStore.WebApi.Controllers.Jogos
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Jogo")]
    public class AtualizarJogoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtualizarJogoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualiza um jogo existente",
            Description = "Altera os dados de um jogo cadastrado."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarJogoCommand command)
        {
            var result = await _mediator.Send(command);

            var response = new
            {
                sucesso = result.Sucesso,
                mensagem = result.Sucesso ? "Jogo atualizado com sucesso." : result.Erro
            };

            return result.Sucesso ? Ok(response) : BadRequest(response);
        }
    }
}
