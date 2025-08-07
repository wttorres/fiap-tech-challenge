using TechChallenge.GameStore.Application.Promocoes.Consultar;

namespace TechChallenge.GameStore.Application.Jogos.Consultar
{
    public interface IConsultaJogoQuery
    {
        Task<List<JogoResponse>> ObterTodosAsync();
        Task<JogoResponse?> ObterPorIdAsync(int id);
    }
}
