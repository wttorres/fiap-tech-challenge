namespace TechChallenge.GameStore.Domain.Jogos;

public interface IJogoRepository
{
    Task<List<Jogo>> ObterAsync(IEnumerable<int> jogosIds);
}
