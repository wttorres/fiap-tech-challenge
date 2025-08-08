using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Application.Jogos.Consultar
{
    public class ConsultaJogoQuery : IConsultaJogoQuery
    {
        private readonly IJogoRepository _repository;

        public ConsultaJogoQuery(IJogoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<JogoResponse>> ObterTodosAsync()
        {
            var jogos = await _repository.ObterTodosAsync();
            return jogos.Select(Mapear).ToList();
        }

        public async Task<JogoResponse?> ObterPorIdAsync(int id)
        {
            var jogo = await _repository.ObterPorIdAsync(id);
            return jogo is null ? null : Mapear(jogo);
        }

        private static JogoResponse Mapear(Jogo jogo)
        {
            return new JogoResponse
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Preco = jogo.Preco
            };
        }
    }
}
