using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain.Notificacoes;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Notificacoes.Fakers;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Notificacoes.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Notificacoes;

public class NotificacaoRepositoryTest
{
    [Fact]
    public async Task Adicionar_DevePersistirNotificacaoNoContexto()
    {
        // Arrange
        using var fixture = new NotificacaoRepositoryFixture();
        var notificacao = NotificacaoFaker.Valida();

        // Act
        fixture.Repository.Adicionar(notificacao);
        await fixture.Repository.SaveChangesAsync();

        // Assert
        var persisted = await fixture.Context.Set<Notificacao>().FindAsync(notificacao.Id);
        persisted.Should().NotBeNull();
        persisted!.Titulo.Should().Be(notificacao.Titulo);
    }

    [Fact]
    public async Task ObterUsuariosNaoNotificadosAsync_QuandoExistemEnviados_DeveRetornarSomenteNaoEnviados()
    {
        // Arrange
        using var fixture = new NotificacaoRepositoryFixture();
        var notificacao = NotificacaoFaker.Valida();
        fixture.Repository.Adicionar(notificacao);
        await fixture.Repository.SaveChangesAsync();

        var usuarioIds = new List<int> { 1, 2, 3 };
        notificacao.AdicionarEnvio(1, 999); // Enviado para o usuário 1

        await fixture.Context.SaveChangesAsync();

        // Act
        var resultado = await fixture.Repository.ObterUsuariosNaoNotificadosAsync(999, usuarioIds);

        // Assert
        resultado.Should().BeEquivalentTo(new List<int> { 2, 3 });
    }

    [Fact]
    public async Task SaveChangesAsync_DevePersistirMudancas()
    {
        // Arrange
        using var fixture = new NotificacaoRepositoryFixture();
        var notificacao = NotificacaoFaker.Valida();

        // Act
        fixture.Repository.Adicionar(notificacao);
        await fixture.Repository.SaveChangesAsync();

        // Assert
        var exists = await fixture.Context.Set<Notificacao>().AnyAsync(n => n.Id == notificacao.Id);
        exists.Should().BeTrue();
    }
}
