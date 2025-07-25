using AutoBogus;
using TechChallenge.GameStore.Application.Jogos.Cadastrar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Jogos.Fakers;

public static class CadastrarJogoCommandFaker
{
    public static CadastrarJogoCommand Valido()
    {
        return new AutoFaker<CadastrarJogoCommand>().Generate();
    }
}
