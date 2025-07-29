namespace TechChallenge.GameStore.Domain.Usuarios
{
    public interface IBibliotecaJogosRepository
    {
        Task<bool> UsuarioJaPossuiJogoAsync(int usuarioId, int jogoId);
        Task AdicionarAsync(int usuarioId, int jogoId);
        Task<List<BibliotecaJogo>> ObterPorUsuarioIdAsync(int usuarioId);
    }
}
