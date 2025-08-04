using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Domain.Promocoes;

public interface IPromocaoRepository
{
    Task<bool> ExisteAsync(string nome);
    Task<Result<string>> ExcluirAsync(Promocao promocao);
    Task<Result<string>> AtualizarAsync(Promocao promocao);
    Task<Result<Promocao>> AdicionarAsync(Promocao promocao);
    Task<Promocao?> ObterPorIdAsync(int promocaoId);
    Task<List<Promocao>> ObterTodasAsync();
    Task<List<Promocao>> ObterPromocoesAtivasComJogosAsync();
    Task<List<PromocaoJogo>> ObterPorJogosIdsAsync(List<int> jogoIds);
}