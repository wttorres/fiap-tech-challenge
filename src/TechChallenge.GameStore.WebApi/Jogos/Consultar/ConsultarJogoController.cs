using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Application.Jogos.Consultar;

namespace TechChallenge.GameStore.WebApi.Jogos.Consultar;

[ApiController]
[Route("api/jogos")]
[ApiExplorerSettings(GroupName = "Jogos")]
public class ConsultarJogoController : ControllerBase
{
    private readonly IConsultaJogoQuery _consulta;

    public ConsultarJogoController(IConsultaJogoQuery consulta)
    {
        _consulta = consulta;
    }

    [Authorize]
    [HttpGet("{jogoId}")]
    [SwaggerOperation(
        Summary = "Consulta um jogo por ID",
        Description = "Retorna os dados de um jogo específico."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var jogo = await _consulta.ObterPorIdAsync(id);
        if (jogo is null)
            return NotFound(new { sucesso = false, mensagem = "Jogo não encontrado." });

        return Ok(new { sucesso = true, jogo });
    }
    
    [Authorize]
    [HttpGet]
    [SwaggerOperation(
        Summary = "Lista todos os jogos",
        Description = "Retorna todos os jogos cadastrados."
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterTodos()
    {
        var jogos = await _consulta.ObterTodosAsync();
        return Ok(new { sucesso = true, jogos });
    }
}