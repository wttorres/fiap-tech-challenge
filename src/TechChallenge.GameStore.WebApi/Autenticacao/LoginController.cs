using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Application.Autenticacao;

namespace TechChallenge.GameStore.WebApi.Autenticacao;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Login")]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Realizar login",
        Description = "Retorna token JTW caso sucesso")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var response = await _mediator.Send(command);

        if (response is null)
            return Unauthorized();

        return Ok(response);
    }
}