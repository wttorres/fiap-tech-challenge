using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Notificacoes.Fakers;

public static class JogoFaker
{
    public static Jogo Valido()
    {
        var result = Jogo.Criar("Elden Ring", 199.90m);
        return result.Valor!;
    }

    public static Jogo ComNome(string nome)
    {
        var result = Jogo.Criar(nome, 150.00m);
        return result.Valor!;
    }
}
