using System.Collections.Generic;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Fakers;

using AutoBogus;
using TechChallenge.GameStore.Domain.Promocoes;

public static class PromocaoFaker
{
    public static List<Promocao> ComJogos(int quantidade)
    {
        var lista = new List<Promocao>();

        for (var i = 0; i < quantidade; i++)
        {
            var promocao = new Promocao();

            var promocaoJogos = new AutoFaker<PromocaoJogo>().Generate(2);

            foreach (var promocaoJogo in promocaoJogos)
            {
                var jogo = new AutoFaker<Jogo>().Generate();
                promocaoJogo.AdicionarJogo(jogo);
                promocao.Jogos.Add(promocaoJogo);
            }

            lista.Add(promocao);
        }

        return lista;
    }
    
    public static List<Promocao> ComUmJogo()
    {
        var lista = new List<Promocao>(); 
        var promocaoJogos = new AutoFaker<PromocaoJogo>().Generate(1);

        var promocao = new Promocao();
        foreach (var promocaoJogo in promocaoJogos)
        {
            var jogo = new AutoFaker<Jogo>().Generate();
            promocaoJogo.AdicionarJogo(jogo);
            promocao.Jogos.Add(promocaoJogo);
        }

        lista.Add(promocao);

        return lista;
    }
}

