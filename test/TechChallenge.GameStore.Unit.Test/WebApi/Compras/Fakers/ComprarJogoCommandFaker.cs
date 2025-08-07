using AutoBogus;
using System.Collections.Generic;
using TechChallenge.GameStore.Application.Compras.Cadastrar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras.Fakers;

public static class ComprarJogoCommandFaker
{
    public static ComprarJogoCommand Valido()
    {
        return new AutoFaker<ComprarJogoCommand>()
            .RuleFor(x => x.UsuarioId, f => f.Random.Int(1, 1000))
            .RuleFor(x => x.JogosIds, f => f.Make(3, () => f.Random.Int(1, 1000)))
            .Generate();
    }

    public static ComprarJogoCommand Invalido_SemUsuario()
    {
        return new AutoFaker<ComprarJogoCommand>()
            .RuleFor(x => x.UsuarioId, _ => 0)
            .RuleFor(x => x.JogosIds, f => f.Make(2, () => f.Random.Int(1, 1000)))
            .Generate();
    }

    public static ComprarJogoCommand Invalido_SemJogos()
    {
        return new AutoFaker<ComprarJogoCommand>()
            .RuleFor(x => x.UsuarioId, f => f.Random.Int(1, 1000))
            .RuleFor(x => x.JogosIds, _ => new List<int>())
            .Generate();
    }
}
