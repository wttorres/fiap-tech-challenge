using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fakers;

public static class ResultFaker
{
    public static Result<string> Sucesso(string valor)
        => Result.Success(valor);

    public static Result<string> Falha(string erro)
        => Result.Failure<string>(erro);
}