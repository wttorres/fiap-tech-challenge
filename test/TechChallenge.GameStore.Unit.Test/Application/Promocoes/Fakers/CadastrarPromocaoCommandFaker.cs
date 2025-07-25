using System;
using System.Collections.Generic;
using AutoBogus;
using TechChallenge.GameStore.Application.Promocoes.Cadastar;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fakers;

public static class CadastrarPromocaoCommandFaker
{
    public static CadastrarPromocaoCommand Valido()
    {
        return new AutoFaker<CadastrarPromocaoCommand>()
            .RuleFor(c => c.JogosIds, f => new List<int> { 1, 2 })
            .RuleFor(c => c.DataInicio, f => DateTime.Now)
            .RuleFor(c => c.DataFim, f => DateTime.Now.AddDays(4))
            .Generate();
    }

    public static CadastrarPromocaoCommand SemNomePromocao()
    {
        return new CadastrarPromocaoCommand
        {
            Nome = "",
            JogosIds = new List<int> { 3 }
        };
    }

    public static CadastrarPromocaoCommand SemJogos()
    {
        return new AutoFaker<CadastrarPromocaoCommand>()
            .RuleFor(c => c.JogosIds, new List<int>())
            .RuleFor(c => c.DataInicio, f => DateTime.Now)
            .RuleFor(c => c.DataFim, f => DateTime.Now.AddDays(4))
            .Generate();
    }
}