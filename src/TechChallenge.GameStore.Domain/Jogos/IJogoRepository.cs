using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Domain.Jogos
{
    public interface IJogoRepository
    {
        Task<Jogo?> ObterPorIdAsync(int id);
        Task<Jogo?> ObterPorNome(string nome);
        Task<List<Jogo>> ObterTodosAsync();
        Task<List<Jogo>> ObterPorIdsAsync(List<int> ids);
        Task<Result<Jogo>> AdicionarAsync(Jogo jogo);
        Task AtualizarAsync(Jogo jogo);
        Task RemoverAsync(Jogo jogo);
    }
}
