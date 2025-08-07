using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Application.Promocoes.Atualizar;

public class AtualizarPromocaoHandler : IRequestHandler<AtualizarPromocaoCommand, Result<string>>
{
    private readonly IJogoRepository _jogoRepository;
    private readonly IPromocaoRepository _promocaoRepository;

    public AtualizarPromocaoHandler(
        IJogoRepository jogoRepository,
        IPromocaoRepository promocaoRepository)
    {
        _jogoRepository = jogoRepository;
        _promocaoRepository = promocaoRepository;
    }

    public async Task<Result<string>> Handle(AtualizarPromocaoCommand request, CancellationToken cancellationToken)
    {
        var promocao = await _promocaoRepository.ObterPorIdAsync(request.Id);
        if (promocao is null)
            return Result.Failure<string>("Promoção não encontrada.");

        var jogosValidos = await ValidarJogosExistentes(request.JogosIds!);
        if (!jogosValidos.Sucesso)
            return jogosValidos;

        var conflitos = await VerificarConflitosDePromocao(request.Id, request.JogosIds!);
        if (conflitos.Any())
        {
            var idsConflitantes = string.Join(", ", conflitos);
            return Result.Failure<string>($"Os jogos {idsConflitantes} já estão vinculados a outras promoções.");
        }

        return await AtualizarDadosDaPromocaoAsync(promocao, request);
    }
    
    private async Task<Result<string>> ValidarJogosExistentes(List<int> jogosIds)
    {
        var jogos = await _jogoRepository.ObterPorIdsAsync(jogosIds);
        
        return jogos.Count == jogosIds.Count
            ? Result.Success("Jogos válidos")
            : Result.Failure<string>("Um ou mais jogos informados não existem.");
    }

    private async Task<List<int>> VerificarConflitosDePromocao(int idPromocaoAtual, List<int> jogosIds)
    {
        var jogosEmPromocao = await _promocaoRepository.ObterPorJogosIdsAsync(jogosIds);
        
        return jogosEmPromocao
            .Where(j => j.PromocaoId != idPromocaoAtual)
            .Select(j => j.JogoId)
            .Distinct()
            .ToList();
    }

    private async Task<Result<string>> AtualizarDadosDaPromocaoAsync(Promocao promocao, AtualizarPromocaoCommand request)
    {
        promocao.Atualizar(
            request.Nome,
            request.Descricao,
            request.DescontoPercentual,
            request.DataInicio,
            request.DataFim);

        promocao.AtualizarJogos(request.JogosIds!);
        
        return await _promocaoRepository.AtualizarAsync(promocao);
    }
}
