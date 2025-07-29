using System.Collections.Generic;
using AutoBogus;
using TechChallenge.GameStore.Application.Promocoes.Consultar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fakers;

public static class PromocaoResponseFaker
{
    public static PromocaoResponse Gerar()
    {
        return new AutoFaker<PromocaoResponse>().Generate();
    }

    public static List<PromocaoResponse> GerarLista(int tamanho)
    {
        return new AutoFaker<PromocaoResponse>().Generate(tamanho);
    }
}