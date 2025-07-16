namespace TechChallenge.GameStore.Domain.Usuarios;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task<Usuario> AdicionarAsync(Usuario usuario);
    Task<List<Usuario>> ObterTodosAsync();
}