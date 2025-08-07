using AutoBogus;
using TechChallenge.GameStore.Application.Autenticacao;

namespace TechChallenge.GameStore.Unit.Test.Application.Autenticacao.Fakers;

public static class LoginCommandFaker
{
    public static LoginCommand Valido(string senhaHash)
    {
        return new AutoFaker<LoginCommand>()
            .RuleFor(x => x.Senha, f => senhaHash)
            .Generate();
    }

    public static LoginCommand ComSenhaIncorreta()
    {
        return new AutoFaker<LoginCommand>()
            .RuleFor(x => x.Senha, f => "senhaErrada123!")
            .Generate();
    }
}