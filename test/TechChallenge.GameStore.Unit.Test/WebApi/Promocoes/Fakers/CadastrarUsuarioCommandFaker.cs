using AutoBogus;
using TechChallenge.GameStore.Application.Promocoes.Cadastar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fakers;

public static class CadastrarUsuarioCommandFaker
{
    public static CadastrarPromocaoCommand Valido()
    {
        return new AutoFaker<CadastrarPromocaoCommand>().Generate();
    }
}