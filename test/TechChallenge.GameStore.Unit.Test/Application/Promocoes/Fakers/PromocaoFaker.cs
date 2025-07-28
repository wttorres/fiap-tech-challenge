using System;
using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fakers;

public static class PromocaoFaker
{
    public static List<Jogo> JogosValidos(List<int> ids)
    {
        return ids.Select(id => new AutoFaker<Jogo>()
            .RuleFor(j => j.Id, id)
            .Generate()).ToList();
    }

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
}