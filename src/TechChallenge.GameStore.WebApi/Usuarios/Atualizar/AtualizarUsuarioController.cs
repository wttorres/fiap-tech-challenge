using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using TechChallenge.GameStore.Application.Usuarios.Atualizar;

namespace TechChallenge.GameStore.WebApi.Usuarios.Atualizar;

[Route("api/[controller]")]
[ApiController]
public class AtualizarUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public AtualizarUsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Atualiza um usuário existente",
        Description = "Atualiza nome e senha de um usuário existente. E-mail não pode ser alterado.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID da URL e do corpo não correspondem.");

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
