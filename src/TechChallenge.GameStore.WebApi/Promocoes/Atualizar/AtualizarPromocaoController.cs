using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Application.Promocoes.Atualizar;

namespace TechChallenge.GameStore.WebApi.Promocoes.Atualizar;

[ApiController]
[Route("api/promocoes")]
[ApiExplorerSettings(GroupName = "Promoção")]
public class AtualizarPromocaoController : ControllerBase
{
    private readonly IMediator _mediator;

    public AtualizarPromocaoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    [SwaggerOperation(
        Summary = "Atualiza uma promoção existente",
        Description = "Realiza a atualização de uma promoção de jogo existente."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarPromocaoCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new
        {
            sucesso = result.Sucesso,
            mensagem = result.Sucesso ? "Promoção atualizada com sucesso." : result.Erro,
            valor = result.Sucesso ? result.Valor : null
        };

        return result.Sucesso ? Ok(response) : BadRequest(response);
    }
}