using System;
using System.Collections.Generic;
using System.Linq;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras.Fakers;

public static class HistoricoCompraFaker
{
    public static HistoricoCompra ParaUsuarioComJogos(int usuarioId, List<Jogo> jogos)
    {
        var itens = jogos.Select(j => new ItemCompra
        {
            JogoId = j.Id,
            Jogo = j,
            PrecoPago = j.Preco
        }).ToList();

        return new HistoricoCompra
        {
            UsuarioId = usuarioId,
            DataCompra = DateTime.UtcNow,
            Itens = itens
        };
    }
}
