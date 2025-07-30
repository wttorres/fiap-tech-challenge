using AutoBogus;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Domain.Notificacoes.Fakers;

public static class JogoFaker
{
    public static Jogo Valido()
    {
        return new AutoFaker<Jogo>()
            .RuleFor(j => j.Nome, f => f.Commerce.ProductName())
            .Generate();
    }
}