using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using TechChallenge.GameStore.Application.Jogos.Cadastrar;

namespace TechChallenge.GameStore.WebApi.Jogos.Cadastrar;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Jogo")]
public class CadastrarJogoController : ControllerBase
{
    private readonly IMediator _mediator;

    public CadastrarJogoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Cadastra um novo jogo",
        Description = "Realiza o cadastro de um jogo informando nome, preço."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarJogoCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new
        {
            sucesso = result.Sucesso,
            mensagem = result.Sucesso ? "Jogo cadastrado com sucesso." : result.Erro,
            valor = result.Sucesso ? result.Valor : null
        };

        return result.Sucesso ? Ok(response) : BadRequest(response);
    }
}