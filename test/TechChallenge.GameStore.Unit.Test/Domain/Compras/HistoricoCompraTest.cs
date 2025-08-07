using FluentAssertions;
using System;
using System.Collections.Generic;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Usuarios;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Domain.Compras;

public class HistoricoCompraTest
{
    [Fact]
    public void Instanciar_QuandoDadosValidos_DevePopularCorretamente()
    {
        // Arrange
        var usuario = Usuario.Criar("Jogador 1", "jogador1@email.com", "Senha123@").Valor!;
        var dataCompra = DateTime.UtcNow;
        var item = new ItemCompra
        {
            JogoId = 1,
            PrecoPago = 89.99m
        };

        // Act
        var historico = new HistoricoCompra
        {
            UsuarioId = usuario.Id,
            Usuario = usuario,
            DataCompra = dataCompra,
            Itens = new List<ItemCompra> { item }
        };

        // Assert
        historico.UsuarioId.Should().Be(usuario.Id);
        historico.Usuario.Should().Be(usuario);
        historico.DataCompra.Should().BeCloseTo(dataCompra, precision: TimeSpan.FromSeconds(1));
        historico.Itens.Should().HaveCount(1);
        historico.Itens[0].JogoId.Should().Be(1);
        historico.Itens[0].PrecoPago.Should().Be(89.99m);
    }
}
