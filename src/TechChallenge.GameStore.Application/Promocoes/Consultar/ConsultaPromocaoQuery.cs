using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Application.Promocoes.Consultar;

public class ConsultaPromocaoQuery : IConsultaPromocaoQuery
{
    private readonly IPromocaoRepository _repository;

    public ConsultaPromocaoQuery(IPromocaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<PromocaoResponse?> ObterPorIdAsync(int id)
    {
        var promocao = await _repository.ObterPorIdAsync(id);

        return promocao is null ? null : Mapear(promocao);
    }

    public async Task<List<PromocaoResponse>> ObterTodasAsync()
    {
        var promocoes = await _repository.ObterTodasAsync();
        
        return promocoes.Select(Mapear).ToList();
    }

    private static PromocaoResponse Mapear(Promocao promocao)
    {
        return new PromocaoResponse
        {
            Id = promocao.Id,
            Nome = promocao.Nome,
            Descricao = promocao.Descricao,
            DescontoPercentual = promocao.DescontoPercentual,
            DataInicio = promocao.DataInicio,
            DataFim = promocao.DataFim,
            Jogos = promocao.Jogos
                .Select(j => new JogoResponse
                {
                    Id = j.Jogo.Id,
                    Nome = j.Jogo.Nome,
                    Preco = j.Jogo.Preco
                })
                .ToList()
        };
    }
}