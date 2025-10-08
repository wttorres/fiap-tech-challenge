using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Application.Usuarios.Consultar;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios;

public class ConsultarTodosUsuariosHandlerTest : ConsultarTodosUsuariosHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoUsuariosExistem_DeveRetornarListaOrdenada()
    {
        // Arrange
        var usuariosNaoOrdenados = UsuarioFaker.ListaNaoOrdenadaPorId();
        UsuarioRepositoryMock.ConfigurarObterTodos(usuariosNaoOrdenados);

        // Act
        var resultado = await Handler.Handle(new ConsultarTodosUsuariosQuery(), CancellationToken.None);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().BeInAscendingOrder(u => u.Id);
        resultado.Valor.Should().HaveSameCount(usuariosNaoOrdenados);

        UsuarioRepositoryMock.GarantirObterTodosChamado();
    }

    [Fact]
    public async Task Handle_QuandoListaVazia_DeveRetornarListaVazia()
    {
        // Arrange
        UsuarioRepositoryMock.ConfigurarObterTodos(new List<Usuario>());

        // Act
        var resultado = await Handler.Handle(new ConsultarTodosUsuariosQuery(), CancellationToken.None);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().BeEmpty();

        UsuarioRepositoryMock.GarantirObterTodosChamado();
    }
}