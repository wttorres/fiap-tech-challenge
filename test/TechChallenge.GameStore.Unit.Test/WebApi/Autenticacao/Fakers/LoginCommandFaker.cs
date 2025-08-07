using AutoBogus;
using TechChallenge.GameStore.Application.Autenticacao;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Autenticacao.Fakers;

public static class LoginCommandFaker
{
    public static LoginCommand Valido()
    {
        return new AutoFaker<LoginCommand>().Generate();
    }
}