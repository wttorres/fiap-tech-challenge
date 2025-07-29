using System;
using System.Collections.Generic;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Unit.Test.Domain.Promocoes.Fakers;

public static class PromocaoFaker
{
    public static (string nome, string? descricao, decimal desconto, DateTime inicio, DateTime fim) DadosValidos()
    {
        return (
            nome: "Promoção de Verão",
            descricao: "Desconto especial",
            desconto: 25m,
            inicio: DateTime.Today,
            fim: DateTime.Today.AddDays(10)
        );
    }

    public static Result<Promocao> CriarValida()
    {
        var (nome, descricao, desconto, inicio, fim) = DadosValidos();
        return Promocao.Criar(nome, descricao, desconto, inicio, fim);
    }

    public static IEnumerable<int> JogosIdsValidos()
        => new List<int> { 1, 2, 3 };

    public static IEnumerable<int> JogosIdsAlternativos()
        => new List<int> { 10, 20, 30 };
}