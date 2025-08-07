using System;
using System.Collections.Generic;
using System.Linq;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos.Fakers;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Compras.Fakers;

public static class HistoricoCompraFaker
{
    public static HistoricoCompra ParaUsuario(int usuarioId, int compraId = 1)
    {
        var usuario = Usuario.Criar($"Usuario {usuarioId}", $"usuario{usuarioId}@email.com", "Senha123!").Valor!;

        return new HistoricoCompra
        {
            Id = compraId,
            UsuarioId = usuarioId,
            Usuario = usuario,
            DataCompra = DateTime.UtcNow,
            Itens = new List<ItemCompra>
            {
                new ItemCompra
                {
                    JogoId = 1,
                    PrecoPago = 59.90m,
                    Jogo = JogoFaker.ComNome("Jogo Comprado")
                }
            }
        };
    }

    public static List<HistoricoCompra> ListaParaUsuario(int usuarioId, int quantidade = 2)
    {
        var usuario = Usuario.Criar($"Usuario {usuarioId}", $"usuario{usuarioId}@email.com", "Senha123!").Valor!;
        usuario.GetType().GetProperty("Id")?.SetValue(usuario, usuarioId);

        return Enumerable.Range(1, quantidade)
            .Select(i => new HistoricoCompra
            {
                UsuarioId = usuarioId,
                Usuario = usuario, // mesma instância
                DataCompra = DateTime.UtcNow,
                Itens = new List<ItemCompra>
                {
                new ItemCompra
                {
                    JogoId = i,
                    PrecoPago = 59.90m,
                    Jogo = JogoFaker.ComNome($"Jogo {i}")
                }
                }
            })
            .ToList();
    }

}
