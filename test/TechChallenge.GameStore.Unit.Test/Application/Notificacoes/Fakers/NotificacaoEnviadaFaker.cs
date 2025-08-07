using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Bogus;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Notificacoes;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Fakers;

public static class NotificacaoEnviadaFaker
{
    public static NotificacaoEnviada Valida()
    {
        var faker = new Faker("pt_BR");
        var jogoResult = Jogo.Criar(
            nome: faker.Commerce.ProductName(),
            preco: faker.Random.Decimal(20, 300));
        var jogo = jogoResult.Valor;
        var inicio = faker.Date.Past();
        var fim = faker.Date.Future();
        var promocaoResult = Promocao.Criar(
            nome: faker.Commerce.Department(),
            descricao: faker.Lorem.Sentence(),
            desconto: faker.Random.Decimal(5, 90),
            inicio: inicio,
            fim: fim);
        var promocao = promocaoResult.Valor;
        var promocaoJogo = new PromocaoJogo(jogo.Id, promocao);
        promocaoJogo.AdicionarJogo(jogo);
        
        var notificacao = Notificacao.Criar(jogo, promocao);
        notificacao.AdicionarEnvio(1, promocaoJogo.Id);
        
        return new AutoFaker<NotificacaoEnviada>()
            .RuleFor(n => n.UsuarioId, 1)
            .RuleFor(n => n.PromocaoJogoId, promocaoJogo.Id)
            .RuleFor(n => n.NotificacaoId, 0) 
            .RuleFor(n => n.PromocaoJogo, promocaoJogo)
            .RuleFor(n => n.Notificacao, notificacao)
            .Generate();
    }

    public static List<NotificacaoEnviada> ListaValida(int quantidade = 1)
    {
        return Enumerable.Range(0, quantidade)
            .Select(_ => Valida())
            .ToList();
    }
}
