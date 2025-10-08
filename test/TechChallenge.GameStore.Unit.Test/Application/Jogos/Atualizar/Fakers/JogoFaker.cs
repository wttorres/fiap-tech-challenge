using AutoBogus;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Atualizar.Fakers;

public static class JogoFaker
{
    public static Jogo Valido()
    {
        return new AutoFaker<Jogo>().Generate();
    }
}