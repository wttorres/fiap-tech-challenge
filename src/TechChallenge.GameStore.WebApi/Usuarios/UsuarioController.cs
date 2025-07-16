using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.WebApi.Usuarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _repository.ObterTodosAsync();
            return Ok(usuarios);
        }
    }
}