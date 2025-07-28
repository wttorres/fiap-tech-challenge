using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Domain.Promocoes;

public interface IPromocaoRepository
{
    Task<bool> ExisteAsync(string nome);
    Task<Result<Promocao>> AdicionarAsync(Promocao promocao);
    Task<List<PromocaoJogo>> ObterPorJogosIdsAsync(List<int> jogoIds);
    Task<Promocao?> ObterPorIdAsync(int promocaoId);
    Task<Result<string>> ExcluirAsync(Promocao promocao);
}