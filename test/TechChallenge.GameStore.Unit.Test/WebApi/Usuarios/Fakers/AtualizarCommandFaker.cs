using AutoBogus;
using TechChallenge.GameStore.Application.Usuarios.Atualizar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fakers;

public static class AtualizarCommandFaker
{
    public static AtualizarCommand Valido()
    {
        return new AutoFaker<AtualizarCommand>().Generate();
    }
}