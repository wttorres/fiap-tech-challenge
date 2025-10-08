using AutoBogus;
using TechChallenge.GameStore.Application.Jogos.Atualizar;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Atualizar.Fakers;

public static class AtualizarJogoCommandFaker
{
    public static AtualizarJogoCommand Valido()
    {
        return new AutoFaker<AtualizarJogoCommand>().Generate();
    }
}