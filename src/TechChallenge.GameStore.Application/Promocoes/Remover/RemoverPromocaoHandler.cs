using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Application.Promocoes.Remover;

public class RemoverPromocaoHandler : IRequestHandler<RemoverPromocaoCommand, Result<string>>
{
    private readonly IPromocaoRepository _promocaoRepository;

    public RemoverPromocaoHandler(IPromocaoRepository promocaoRepository)
    {
        _promocaoRepository = promocaoRepository;
    }

    public async Task<Result<string>> Handle(RemoverPromocaoCommand request, CancellationToken cancellationToken)
    {
        var promocao = await _promocaoRepository.ObterPorIdAsync(request.PromocaoId);

        return promocao is null
            ? Result.Failure<string>("A promoção informada não existe")
            : await _promocaoRepository.ExcluirAsync(promocao);
    }
}