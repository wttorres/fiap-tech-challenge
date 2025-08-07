using System.Collections.Generic;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Domain.Usuarios;

public interface IUsuarioRepository
{
    Task<Usuario> ObterPorIdAsync(int id);
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task<Result<Usuario>> AdicionarAsync(Usuario usuario);
    Task<List<Usuario>> ObterTodosAsync();
    Task<Result<Usuario>> AtualizarAsync(Usuario usuario);
    Task<List<Usuario>> ObterUsuariosQueRecebemNotificacoesAsync();
}