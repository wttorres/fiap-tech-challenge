using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TechChallenge.GameStore.Application.Compras.Cadastrar;

namespace TechChallenge.GameStore.WebApi.Compras.Cadastrar;

[ApiController]
[Route("api/")]
[ApiExplorerSettings(GroupName = "Compras")]
public class ComprarJogoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ComprarJogoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpPost("ComprarJogo")]
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