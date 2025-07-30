using System.Collections.Generic;
using System.Linq;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos.Fakers;

public static class JogoFaker
{
    public static Jogo Valido()
    {
        var result = Jogo.Criar("Elden Ring", 199.90m);
        return result.Valor!;
    }

    public static Jogo ComNome(string nome)
    {
        var result = Jogo.Criar(nome, 150.00m);
        return result.Valor!;
    }
    public static List<Jogo> Lista(List<int> ids)
    {
        return ids.Select(id =>
        {
            var result = Jogo.Criar($"Jogo {id}", 99.99m);
            var jogo = result.Valor!;
            jogo.GetType().GetProperty("Id")?.SetValue(jogo, id);
            return jogo;
        }).ToList();
    }
}
