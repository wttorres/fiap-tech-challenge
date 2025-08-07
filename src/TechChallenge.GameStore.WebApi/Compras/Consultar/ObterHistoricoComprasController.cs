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
[Route("api/compras")]
[ApiExplorerSettings(GroupName = "Compras")]
public class ObterHistoricoComprasController : ControllerBase
{
    private readonly IMediator _mediator;

    public ObterHistoricoComprasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("{usuarioId}")]
    [SwaggerOperation(
        Summary = "Lista o histórico de compras de um usuário",
        Description = "Retorna todas as compras feitas por um usuário, com os jogos adquiridos e valores pagos."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterHistorico(int usuarioId)
    {
        var result = await _mediator.Send(new ConsultaHistoricoComprasQuery(usuarioId));

        if (!result.Sucesso || result.Valor is null || !result.Valor.Any())
            return NotFound(new { sucesso = false, mensagem = "Nenhuma compra encontrada para o usuário." });

        return Ok(new
        {
            sucesso = true,
            compras = result.Valor
        });
    }
}