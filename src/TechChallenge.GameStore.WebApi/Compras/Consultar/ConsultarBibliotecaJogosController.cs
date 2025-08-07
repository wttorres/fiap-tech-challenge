using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TechChallenge.GameStore.Application.Compras.Consultar;

namespace TechChallenge.GameStore.WebApi.Compras.Consultar;

[ApiController]
[Route("api/BibliotecaJogos")]
[ApiExplorerSettings(GroupName = "Compras")]
public class ConsultarBibliotecaJogosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConsultarBibliotecaJogosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("{usuarioId}")]
    [SwaggerOperation(
        Summary = "Lista jogos adquiridos por um usuário",
        Description = "Retorna os jogos comprados por um usuário com nome, valor pago e data da compra."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListarJogosAdquiridos(int usuarioId)
    {
        var result = await _mediator.Send(new ConsultaBibliotecaJogosQuery(usuarioId));

        if (!result.Sucesso || result.Valor == null || !result.Valor.Any())
            return NotFound(new { sucesso = false, mensagem = "Nenhum jogo encontrado para o usuário." });

        return Ok(new
        {
            sucesso = true,
            jogos = result.Valor
        });
    }
}