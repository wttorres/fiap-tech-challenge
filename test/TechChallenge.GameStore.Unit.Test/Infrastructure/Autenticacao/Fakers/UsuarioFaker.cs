using AutoBogus;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Autenticacao.Fakers;

public static class UsuarioFaker
{
    public static Usuario Valido()
    {
        return new AutoFaker<Usuario>()
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .Generate();
    }
}