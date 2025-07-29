using AutoBogus;
using TechChallenge.GameStore.Application.Promocoes.Atualizar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fakers;

public static class AtualizarPromocaoCommandFaker
{
    public static AtualizarPromocaoCommand Valido()
        => new AutoFaker<AtualizarPromocaoCommand>().Generate();
}