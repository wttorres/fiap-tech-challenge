using AutoBogus;
using System.Collections.Generic;
using TechChallenge.GameStore.Application.Compras.Cadastrar;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras.Fakers;

public static class ComprarJogoCommandFaker
{
    public static ComprarJogoCommand Valido()
    {
        return new AutoFaker<ComprarJogoCommand>()
            .RuleFor(c => c.UsuarioId, f => f.Random.Int(1, 1000))
            .RuleFor(c => c.JogosIds, f => f.Make(3, () => f.Random.Int(1, 100)))
            .Generate();
    }

    public static ComprarJogoCommand Invalido_SemJogos()
    {
        return new ComprarJogoCommand
        {
            UsuarioId = 1,
            JogosIds = new List<int>()
        };
    }

    public static ComprarJogoCommand Invalido_SemUsuario()
    {
        return new ComprarJogoCommand
        {
            UsuarioId = 0,
            JogosIds = new List<int> { 1, 2 }
        };
    }
}
