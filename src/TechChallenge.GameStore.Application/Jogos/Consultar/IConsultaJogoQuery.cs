using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechChallenge.GameStore.Application.Jogos.Consultar
{
    public interface IConsultaJogoQuery
    {
        Task<List<JogoResponse>> ObterTodosAsync();
        Task<JogoResponse?> ObterPorIdAsync(int id);
    }
}
