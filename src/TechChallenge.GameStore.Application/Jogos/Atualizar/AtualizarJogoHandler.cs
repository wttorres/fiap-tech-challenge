using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Application.Jogos.Atualizar
{
    public class AtualizarJogoHandler : IRequestHandler<AtualizarJogoCommand, Result<bool>>
    {
        private readonly IJogoRepository _repository;

        public AtualizarJogoHandler(IJogoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<bool>> Handle(AtualizarJogoCommand request, CancellationToken cancellationToken)
        {
            var jogo = await _repository.ObterPorIdAsync(request.Id);
            if (jogo is null)
                return Result.Failure<bool>("Jogo não encontrado.");

            jogo.Atualizar(request.Nome, request.Preco);
            await _repository.AtualizarAsync(jogo);

            return Result.Success(true);
        }
    }
}
