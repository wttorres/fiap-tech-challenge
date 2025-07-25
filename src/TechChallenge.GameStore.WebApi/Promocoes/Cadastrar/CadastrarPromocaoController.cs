using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Application.Promocoes.Cadastar;

namespace TechChallenge.GameStore.WebApi.Promocoes.Cadastrar;

[ApiController]
[Route("api/[controller]")]
public class CadastrarPromocaoController : ControllerBase
{
    private readonly IMediator _mediator;

    public CadastrarPromocaoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Cadastra uma nova promoção",
        Description = "Realiza o cadastro de uma nova promoção de jogo."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarPromocaoCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new
        {
            sucesso  = result.Sucesso,
            mensagem = result.Sucesso ? "Promoção cadastrada com sucesso." : result.Erro,
            valor    = result.Sucesso ? result.Valor : null
        };

        return result.Sucesso ? Ok(response) : BadRequest(response);
    }
}