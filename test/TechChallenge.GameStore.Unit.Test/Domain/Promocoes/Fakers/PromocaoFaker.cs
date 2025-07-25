using System;
using System.Collections.Generic;
using Bogus;

namespace TechChallenge.GameStore.Unit.Test.Domain.Promocoes.Fakers;

public static class PromocaoFaker
{
    public static (string nome, string descricao, decimal desconto, DateTime inicio, DateTime fim) DadosValidos()
    {
        var faker = new Faker();
        var inicio = DateTime.Today;
        var fim = inicio.AddDays(10);

        return (
            nome: faker.Random.Word(),
            descricao: faker.Lorem.Sentence(),
            desconto: faker.Random.Decimal(1, 100),
            inicio: inicio,
            fim: fim
        );
    }

    public static IEnumerable<int> JogosIdsValidos()
    {
        return new List<int> { 1, 2, 3 };
    }
}