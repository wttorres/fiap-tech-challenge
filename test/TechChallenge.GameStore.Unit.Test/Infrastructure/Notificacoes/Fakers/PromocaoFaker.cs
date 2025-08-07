using System;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Notificacoes.Fakers;

public static class PromocaoFaker
{
    public static Promocao Valida()
    {
        var result = Promocao.Criar(
            "Black Friday",
            "Desconto especial",
            20,
            DateTime.Today,
            DateTime.Today.AddDays(7)
        );

        return result.Valor;
    }

    public static Promocao ComNome(string nome)
    {
        var result = Promocao.Criar(
            nome,
            "Desc",
            10,
            DateTime.Today,
            DateTime.Today.AddDays(1)
        );

        return result.Valor;
    }
}