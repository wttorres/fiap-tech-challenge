using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Domain.Jogos;

public class Jogo
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public bool Ativo { get; private set; }

    public Jogo() { }

    public Jogo(string nome, decimal preco, bool ativo = true)
    {
        Nome = nome;
        Preco = preco;
        Ativo = ativo;
    }

    public static Result<Jogo> Criar(string nome, decimal preco)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return Result.Failure<Jogo>("Nome é obrigatório.");

        if (preco <= 0)
            return Result.Failure<Jogo>("Preço inválido.");

        var jogo = new Jogo(nome, preco, true);

        return Result.Success(jogo);
    }

    public void Ativar() => Ativo = true;
    public void Inativar() => Ativo = false;

    public static async Task<Result<string>> InativarJogo(IJogoRepository _jogoRepository, int jogoId)
    {
        var jogo = await _jogoRepository.ObterAsync(new[] { jogoId });
        if (jogo == null || !jogo.Any())
            return Result.Failure<string>("Jogo não encontrado.");

        jogo[0].Inativar();
        var resultado = await _jogoRepository.AtualizarAsync(jogo[0]);
        if (!resultado.Sucesso)
            return Result.Failure<string>(resultado.Erro);

        return Result.Success("Jogo inativado com sucesso");
    }
}