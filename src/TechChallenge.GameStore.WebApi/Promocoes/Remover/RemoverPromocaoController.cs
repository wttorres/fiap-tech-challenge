using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Application.Promocoes.Remover;

namespace TechChallenge.GameStore.WebApi.Promocoes.Remover;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Promoção")]
public class RemoverPromocaoController : ControllerBase
{
    private readonly IMediator _mediator;

    public RemoverPromocaoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete]
    [SwaggerOperation(
        Summary = "Excluir promoção",
        Description = "Realiza a exclusão de uma promoção."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromBody] RemoverPromocaoCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new
        {
            sucesso  = result.Sucesso,
            mensagem = result.Sucesso ? "Promoção removida com sucesso." : result.Erro,
            valor    = result.Sucesso ? result.Valor : null
        };

        return result.Sucesso ? Ok(response) : BadRequest(response);
    }
}