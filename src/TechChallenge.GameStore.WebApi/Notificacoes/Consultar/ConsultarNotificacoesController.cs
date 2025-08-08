using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Application.Notificacoes.Consultar;

namespace TechChallenge.GameStore.WebApi.Notificacoes.Consultar;

[ApiController]
[Route("api/notificacoes")]
[ApiExplorerSettings(GroupName = "Notificação")]
public class ConsultarNotificacoesController: ControllerBase
{
    private readonly IConsultaNotificacaoQuery _query;

    public ConsultarNotificacoesController(IConsultaNotificacaoQuery query)
    {
        _query = query;
    }

    [Authorize]
    [HttpGet]
    [SwaggerOperation(
        Summary = "Lista todas as notificações enviadas",
        Description = "Retorna todas as notificações que foram enviadas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListarTodas()
    {
        var notificacoes = await _query.ObterTodasAsync();
        return Ok(notificacoes);
    }
    
    [Authorize]
    [HttpGet("{usuarioId:int}")]
    [SwaggerOperation(
        Summary = "Obtém notificações filtrando por usuário.",
        Description = "Retorna todas as notificações enviadas para um determinado usuário")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorIdUsuario(int usuarioId)
    {
        var notificacoes = await _query.ObterPorIdUsuarioAsync(usuarioId);

        if (notificacoes.Count == 0)
            return NotFound(new { mensagem = "Usuário não possui notificações." });

        return Ok(notificacoes);
    }
    
}