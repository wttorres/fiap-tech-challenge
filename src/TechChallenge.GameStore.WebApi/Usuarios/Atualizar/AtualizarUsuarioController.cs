using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TechChallenge.GameStore.Application.Usuarios.Atualizar;

namespace TechChallenge.GameStore.WebApi.Usuarios.Atualizar;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Usuário")]
public class AtualizarUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public AtualizarUsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpPut]
    [SwaggerOperation(
        Summary = "Atualiza um usuário existente",
        Description = "Atualiza nome e senha de um usuário existente. E-mail não pode ser alterado.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new
        {
            sucesso = result.Sucesso,
            mensagem = result.Sucesso ? "Usuário atualizado com sucesso." : result.Erro,
            valor = result.Sucesso ? result.Valor : null
        };

        return result.Sucesso ? Ok(response) : NotFound(response);
    }
}
