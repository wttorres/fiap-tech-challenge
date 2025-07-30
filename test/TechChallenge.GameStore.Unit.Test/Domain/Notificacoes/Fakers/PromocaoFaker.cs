using AutoBogus;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Unit.Test.Domain.Notificacoes.Fakers;

public static class PromocaoFaker
{
    public static Promocao Valida()
    {
        return new AutoFaker<Promocao>()
            .RuleFor(p => p.Nome, f => f.Commerce.Department())
            .RuleFor(p => p.DescontoPercentual, f => f.Random.Decimal(5, 90))
            .Generate();
    }
}