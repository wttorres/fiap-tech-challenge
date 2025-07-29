namespace TechChallenge.GameStore.Application.Promocoes.Consultar;

public class PromocaoResponse
{
    public int Id { get; init; }
    public string Nome { get; init; } = null!;
    public string? Descricao { get; init; }
    public decimal DescontoPercentual { get; init; }
    public DateTime DataInicio { get; init; }
    public DateTime DataFim { get; init; }
    public List<JogoResponse> Jogos { get; init; } = new();
}

public class JogoResponse
{
    public int Id { get; init; }
    public string Nome { get; init; } = null!;
    public decimal Preco { get; init; }
}