using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using TechChallenge.GameStore.Application.Jogos.Comprar;

namespace TechChallenge.GameStore.WebApi.Jogos.Comprar
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Jogo")]
    public class ComprarJogoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComprarJogoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("comprar")]
        [SwaggerOperation(
            Summary = "Realiza a compra de um ou mais jogos",
            Description = "Permite que um usuário compre um ou mais jogos, atualizando sua biblioteca e histórico de compras."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Comprar([FromBody] ComprarJogoCommand command)
        {
            var result = await _mediator.Send(command);

            var response = new
            {
                sucesso = result.Sucesso,
                mensagem = result.Sucesso ? "Compra realizada com sucesso." : result.Erro,
                valor = result.Sucesso ? result.Valor : null
            };

            return result.Sucesso ? Ok(response) : BadRequest(response);
        }
    }
}
