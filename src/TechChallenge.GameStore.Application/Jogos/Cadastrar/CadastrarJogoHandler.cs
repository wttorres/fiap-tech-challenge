using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Application.Jogos.Cadastrar
{
    public class CadastrarJogoHandler : IRequestHandler<CadastrarJogoCommand, Result<string>>
    {
        private readonly IJogoRepository _repository;

        public CadastrarJogoHandler(IJogoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<string>> Handle(CadastrarJogoCommand request, CancellationToken cancellationToken)
        {
            var existente = await _repository.ObterPorNome(request.Nome);

            if (existente is not null)
                return Result.Failure<string>("Jogo já cadastrado.");

            return await CadastrarAsync(request);
        }

        private async Task<Result<string>> CadastrarAsync(CadastrarJogoCommand request)
        {
            var resultado = Jogo.Criar(request.Nome, request.Preco);
            if (!resultado.Sucesso)
                return Result.Failure<string>(resultado.Erro);

            var adicionarResult = await _repository.AdicionarAsync(resultado.Valor);

            return !adicionarResult.Sucesso
                ? Result.Failure<string>(adicionarResult.Erro)
                : Result.Success(adicionarResult.Valor.Id.ToString());
        }
    }
}
