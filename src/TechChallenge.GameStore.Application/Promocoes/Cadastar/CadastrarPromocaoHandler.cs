using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Application.Promocoes.Cadastar;

public class CadastrarPromocaoHandler : IRequestHandler<CadastrarPromocaoCommand, Result<string>>
{
    private readonly IJogoRepository _jogoRepository;
    private readonly IPromocaoRepository _promocaoRepository;

    public CadastrarPromocaoHandler(
        IJogoRepository jogoRepository,
        IPromocaoRepository promocaoRepository)
    {
        _jogoRepository = jogoRepository;
        _promocaoRepository = promocaoRepository;
    }

    public async Task<Result<string>> Handle(CadastrarPromocaoCommand request, CancellationToken cancellationToken)
    {
        var promocaoJaExiste = await _promocaoRepository.ExisteAsync(request.Nome);
        if (promocaoJaExiste)
            return Result.Failure<string>("Promoção já cadastrada.");

        return await CadastrarAsync(request);
    }

    private async Task<Result<string>> CadastrarAsync(CadastrarPromocaoCommand request)
    {
        var result = Promocao.Criar(request.Nome, request.Descricao,
            request.DescontoPercentual, request.DataInicio, request.DataFim);

        if (!result.Sucesso)
            return Result.Failure<string>(result.Erro);

        if (request.JogosIds is { Count: 0 })
            return Result.Failure<string>("Promoção deve conter pelo menos um jogo.");
        
        var jogos = await _jogoRepository.ObterPorIdsAsync(request.JogosIds);
        if (request.JogosIds != null && jogos.Count != request.JogosIds.Count)
            return Result.Failure<string>("Um ou mais jogos informados não existem.");
        
        var jogosEmPromocao = await _promocaoRepository.ObterPorJogosIdsAsync(request.JogosIds);
        if (jogosEmPromocao.Any())
        {
            var nomes = string.Join(", ", jogosEmPromocao.Select(j => j.Jogo.Id));
            return Result.Failure<string>($"Os jogos {nomes} já estão em promoção.");
        }

        result.Valor.AdicionarJogos(request.JogosIds);
        
        await _promocaoRepository.AdicionarAsync(result.Valor);
        
        return Result.Success(result.Valor.Nome);
    }
}
