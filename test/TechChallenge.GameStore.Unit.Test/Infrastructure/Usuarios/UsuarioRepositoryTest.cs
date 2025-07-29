using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Usuarios;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Usuarios.Fakers;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Usuarios.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Usuarios;

public class UsuarioRepositoryTest 
{
    [Fact]
    public async Task ObterPorEmailAsync_QuandoUsuarioExiste_DeveRetornarUsuario()
    {
        // Arrange
        using var fixture = new UsuarioRepositoryFixture();
        var usuario = UsuarioFaker.Valido();
        await fixture.Context.Set<Usuario>().AddAsync(usuario);
        await fixture.Context.SaveChangesAsync();

        // Act
        var resultado = await fixture.Repository.ObterPorEmailAsync(usuario.Email);

        // Assert
        resultado.Should().NotBeNull();
        resultado!.Email.Should().Be(usuario.Email);
    }

    [Fact]
    public async Task ObterPorEmailAsync_QuandoNaoExiste_DeveRetornarNull()
    {
        // Act
        using var fixture = new UsuarioRepositoryFixture();
        var resultado = await fixture.Repository.ObterPorEmailAsync("nao@existe.com");

        // Assert
        resultado.Should().BeNull();
    }

    [Fact]
    public async Task AdicionarAsync_QuandoUsuarioValido_DevePersistir()
    {
        // Arrange
        using var fixture = new UsuarioRepositoryFixture();
        var usuario = UsuarioFaker.Valido();

        // Act
        var resultado = await fixture.Repository.AdicionarAsync(usuario);

        // Assert
        resultado.Sucesso.Should().BeTrue();

        var persistido = await fixture.Context.Set<Usuario>().FirstOrDefaultAsync(x => x.Email == usuario.Email);
        persistido.Should().NotBeNull();
    }

    [Fact]
    public async Task ObterTodosAsync_QuandoExistemUsuarios_DeveRetornarLista()
    {
        // Arrange
        using var fixture = new UsuarioRepositoryFixture();
        var usuario = UsuarioFaker.Valido();
        await fixture.Context.Set<Usuario>().AddAsync(usuario);
        await fixture.Context.SaveChangesAsync();

        // Act
        var lista = await fixture.Repository.ObterTodosAsync();

        // Assert
        lista.Should().NotBeNull();
        lista.Should().ContainSingle();
    }
    
    [Fact]
    public async Task AdicionarAsync_QuandoSaveChangesLancaExcecao_DeveRetornarFalha()
    {
        // Arrange
        var usuario = Usuario.Criar("Teste", "teste@email.com", "Abc@123").Valor!;

        var options = new DbContextOptionsBuilder<GameStoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        // Criamos um proxy que simula erro no SaveChanges
        var contextProxy = new GameStoreContextProxy(options);
        var repository   = new UsuarioRepository(contextProxy);

        // Act
        var resultado = await repository.AdicionarAsync(usuario);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Contain("Erro ao adicionar usuário");
    }

    [Fact]
    public async Task AtualizarAsync_QuandoUsuarioValido_DevePersistir()
    {
        // Arrange
        using var fixture = new UsuarioRepositoryFixture();
        var usuario = UsuarioFaker.Valido();
        await fixture.Context.Set<Usuario>().AddAsync(usuario);
        await fixture.Context.SaveChangesAsync();

        // Modifica o usuário
        usuario.Atualizar("Fulano Junior", null);

        // Act
        var resultado = await fixture.Repository.AtualizarAsync(usuario);

        // Assert
        resultado.Sucesso.Should().BeTrue();

        var persistido = await fixture.Context.Set<Usuario>().FirstOrDefaultAsync(x => x.Id == usuario.Id);
        persistido.Should().NotBeNull();
        persistido!.Nome.Should().Be("Fulano Junior");
    }

    [Fact]
    public async Task AtualizarAsync_QuandoSaveChangesLancaExcecao_DeveRetornarFalha()
    {
        //Arrange
        var usuario = UsuarioFaker.Valido();
        usuario.Atualizar("Joao da Silva", null);

        var options = new DbContextOptionsBuilder<GameStoreContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var contextProxy = new GameStoreContextProxy(options);
        var repository = new UsuarioRepository(contextProxy);

        // Act
        var resultado = await repository.AtualizarAsync(usuario);

        // Assert
        resultado.Sucesso.Should().BeFalse();
    }
}
