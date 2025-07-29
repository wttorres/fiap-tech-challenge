using AutoBogus;
using TechChallenge.GameStore.Application.Promocoes.Atualizar;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fakers;

public static class AtualizarPromocaoCommandFaker
{
    public static AtualizarPromocaoCommand Valido()
    {
        return new AutoFaker<AtualizarPromocaoCommand>()
            .RuleFor(c => c.JogosIds, f => f.Make(2, () => f.Random.Int(1, 100)))
            .Generate();
    }
}