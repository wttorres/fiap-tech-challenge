using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Domain.Promocoes;

public class Promocao
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string? Descricao { get; private set; }
    public decimal DescontoPercentual { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime DataFim { get; private set; }

    public List<PromocaoJogo> Jogos { get; private set; } = new();

    public Promocao() { }

    public static Result<Promocao> Criar(string nome, string? descricao, decimal desconto, DateTime inicio, DateTime fim)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return Result.Failure<Promocao>("Nome da promoção é obrigatório.");

        if (desconto is <= 0 or > 100)
            return Result.Failure<Promocao>("Desconto percentual deve estar entre 1 e 100.");

        if (fim <= inicio)
            return Result.Failure<Promocao>("Data de fim deve ser após a data de início.");

        var promocao = new Promocao
        {
            Nome = nome,
            Descricao = descricao,
            DescontoPercentual = desconto,
            DataInicio = inicio,
            DataFim = fim
        };

        return Result.Success(promocao);
    }

    public void AdicionarJogos(IEnumerable<int> jogosIds)
    {
        foreach (var jogoId in jogosIds)
        {
            Jogos.Add(new PromocaoJogo(jogoId, this));
        }
    }

    public void Atualizar(string nome, string? descricao, decimal desconto, DateTime inicio, DateTime fim)
    {
        Nome = nome;
        Descricao = descricao;
        DescontoPercentual = desconto;
        DataInicio = inicio;
        DataFim = fim;
    }

    public void AtualizarJogos(IEnumerable<int> novosJogoIds)
    {
        Jogos.Clear();
        foreach (var jogoId in novosJogoIds)
            Jogos.Add(new PromocaoJogo(jogoId, this));
    }
}