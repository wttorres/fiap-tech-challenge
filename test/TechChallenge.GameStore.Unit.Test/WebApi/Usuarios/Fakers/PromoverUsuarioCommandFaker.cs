using AutoBogus;
using TechChallenge.GameStore.Application.Usuarios.Promover;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fakers;

public static class PromoverUsuarioCommandFaker
{
    public static PromoverUsuarioCommand Valido()
    {
        return new AutoFaker<PromoverUsuarioCommand>().Generate();
    }
}