using System.Collections.Generic;
using AutoBogus;
using TechChallenge.GameStore.Application.HistoricoCompras;

namespace TechChallenge.GameStore.Unit.Test.WebApi.HistoricoCompras.Fakers;

public static class HistoricoCompraResponseFaker
{
    public static HistoricoCompraResponse.CompraDto GerarCompra()
    {
        return new AutoFaker<HistoricoCompraResponse.CompraDto>().Generate();
    }

    public static List<HistoricoCompraResponse.CompraDto> GerarListaCompras(int tamanho)
    {
        return new AutoFaker<HistoricoCompraResponse.CompraDto>().Generate(tamanho);
    }
}
