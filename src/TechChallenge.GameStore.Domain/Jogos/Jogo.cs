using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Domain.Jogos;

public class Jogo
{
    //Teste
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }

    public Jogo() { }

    public Jogo(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public static Result<Jogo> Criar(string nome, decimal preco)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return Result.Failure<Jogo>("Nome é obrigatório.");

        if (preco <= 0)
            return Result.Failure<Jogo>("Preço inválido.");

        var jogo = new Jogo(nome, preco);

        return Result.Success(jogo);
    }
}