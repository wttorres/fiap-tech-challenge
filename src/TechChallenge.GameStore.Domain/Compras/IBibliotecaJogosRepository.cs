namespace TechChallenge.GameStore.Domain.Compras
{
    public interface IBibliotecaJogosRepository
    {
        Task<bool> UsuarioJaPossuiJogoAsync(int usuarioId, int jogoId);
        Task AdicionarAsync(int usuarioId, int jogoId);
        Task<List<BibliotecaJogo>> ObterPorUsuarioIdAsync(int usuarioId);
    }
}
