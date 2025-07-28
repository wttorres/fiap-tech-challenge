using AutoBogus;
using TechChallenge.GameStore.Application.Promocoes.Remover;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fakers
{
    public static class RemoverPromocaoCommandFaker
    {
        public static RemoverPromocaoCommand ComIdValido()
        {
            return new AutoFaker<RemoverPromocaoCommand>()
                .RuleFor(x => x.PromocaoId, f => f.Random.Int(1, 9999))
                .Generate();
        }
    }
}