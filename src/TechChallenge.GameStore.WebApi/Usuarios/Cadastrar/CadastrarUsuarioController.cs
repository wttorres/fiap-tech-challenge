using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Application.Usuarios.Cadastrar;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace TechChallenge.GameStore.WebApi.Usuarios.Cadastrar;

[ApiController]
[Route("api/[controller]")]
public class CadastrarUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public CadastrarUsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Post")]
    [SwaggerOperation(
        Summary = "Cadastra um novo usuário",
        Description = "Realiza o cadastro de um usuário informando nome, email e senha."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new
        {
            sucesso  = result.Sucesso,
            mensagem = result.Sucesso ? "Usuário cadastrado com sucesso." : result.Erro,
            valor    = result.Sucesso ? result.Valor : null
        };

        return result.Sucesso ? Ok(response) : BadRequest(response);
    }
}