using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using TechChallenge.GameStore.Application.Jogos.Consultar;

namespace TechChallenge.GameStore.WebApi.Controllers.Jogos
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Jogo")]
    public class ConsultarJogoController : ControllerBase
    {
        private readonly IConsultaJogoQuery _consulta;

        public ConsultarJogoController(IConsultaJogoQuery consulta)
        {
            _consulta = consulta;
        }

        [HttpGet("{id}")]
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
}
