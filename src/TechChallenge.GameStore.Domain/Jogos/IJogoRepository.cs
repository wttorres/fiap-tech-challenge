using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Domain.Jogos
{
    public interface IJogoRepository
    {
        Task<Jogo?> ObterPorNome(string nome);
        Task<Result<Jogo>> AdicionarAsync(Jogo jogo);
    }
}
