using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TechChallenge.GameStore.Application.Usuarios.Promover;

namespace TechChallenge.GameStore.WebApi.Usuarios.Promover;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Usuário")]
public class PromoverUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public PromoverUsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("promover")]
    [SwaggerOperation(
        Summary = "Promove o perfil de um usuário",
        Description = "Promove um usuário existente para o perfil de Admin ou Usuário.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Promover([FromBody] PromoverUsuarioCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new
        {
            sucesso = result.Sucesso,
            mensagem = result.Sucesso ? "Usuário promovido com sucesso." : result.Erro,
            valor = result.Sucesso ? result.Valor : null
        };

        return result.Sucesso 
            ? Ok(response)
            : result.Erro == "Usuário não encontrado."
                ? NotFound(response)
                : BadRequest(response);
    }
}