using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Application.Promocoes.Consultar;

namespace TechChallenge.GameStore.WebApi.Promocoes.Consultar;

[ApiController]
[Route("api/promocoes")]
[ApiExplorerSettings(GroupName = "Promoção")]
public class ConsultarPromocaoController : ControllerBase
{
    private readonly IConsultaPromocaoQuery _query;

    public ConsultarPromocaoController(IConsultaPromocaoQuery query)
    {
        _query = query;
    }

    [Authorize]
    [HttpGet]
    [SwaggerOperation(
        Summary = "Lista todas as promoções",
        Description = "Retorna todas as promoções cadastradas com seus respectivos jogos.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarTodas()
    {
        var promocoes = await _query.ObterTodasAsync();
        return Ok(promocoes);
    }
    
    [Authorize]
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Obtém uma promoção por ID",
        Description = "Retorna os dados da promoção e seus jogos vinculados.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var promocao = await _query.ObterPorIdAsync(id);

        if (promocao is null)
            return NotFound(new { mensagem = "Promoção não encontrada." });

        return Ok(promocao);
    }
}