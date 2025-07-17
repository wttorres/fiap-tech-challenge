namespace TechChallenge.GameStore.Domain.Repositories.Usuarios;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task<Usuario> AdicionarAsync(Usuario usuario);
    Task<List<Usuario>> ObterTodosAsync();
}