using System.Collections.Generic;
using AutoBogus;
using TechChallenge.GameStore.Application.Compras.Consultar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras.Fakers;

public static class JogoAdquiridoResponseFaker
{
    public static JogoAdquiridoResponse Gerar()
    {
        return new AutoFaker<JogoAdquiridoResponse>().Generate();
    }

    public static List<JogoAdquiridoResponse> GerarLista(int tamanho)
    {
        return new AutoFaker<JogoAdquiridoResponse>().Generate(tamanho);
    }
}
