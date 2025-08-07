using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
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

    [HttpPut("{id}/promover")]
    [SwaggerOperation(
        Summary = "Promove o perfil de um usuário",
        Description = "Promove um usuário existente para o perfil de Admin ou Usuário.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Promover(int id, [FromBody] PromoverUsuarioCommand command)
    {
        if (id != command.Id)
            return BadRequest("O ID do usuário na URL não corresponde ao ID no corpo da requisição.");

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