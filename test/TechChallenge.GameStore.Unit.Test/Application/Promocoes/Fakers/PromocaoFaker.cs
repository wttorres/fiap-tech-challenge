using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fakers;

public static class PromocaoFaker
{
    public static List<Jogo> JogosValidos(List<int> ids)
    {
        return ids.Select(id => new AutoFaker<Jogo>()
            .RuleFor(j => j.Id, id)
            .Generate()).ToList();
    }
}