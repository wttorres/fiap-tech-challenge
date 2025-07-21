using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar;

public class CadastrarHandlerTest : CadastrarHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoEmailJaCadastrado_DeveRetornarFalha()
    {
        // Arrange
        var command = CadastrarCommandFaker.Valido();
        UsuarioRepositoryMock.ConfigurarParaRetornarUsuarioAoObterPorEmail(UsuarioFaker.ConverterParaUsuario(command));

        // Act
        var resultado = await Handler.Handle(command, default);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Email já cadastrado.");
        UsuarioRepositoryMock.GarantirQueNaoChamouAdicionar();
    }

    [Fact]
    public async Task Handle_QuandoUsuarioEhValido_DeveAdicionarEDevolverId()
    {
        // Arrange
        var command = CadastrarCommandFaker.Valido();
        UsuarioRepositoryMock.ConfigurarParaRetornarUsuarioAoObterPorEmail(null);

        var usuario = Usuario.Criar(command.Nome, command.Email, command.Senha).Valor;
        UsuarioRepositoryMock.ConfigurarParaRetornarUsuarioAoAdicionar(Result.Success(usuario));

        // Act
        var resultado = await Handler.Handle(command, default);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().Be(usuario.Id.ToString());
        UsuarioRepositoryMock.GarantirChamadaAdicionar();
    }

    [Fact]
    public async Task Handle_QuandoUsuarioInvalido_DeveRetornarErro()
    {
        // Arrange
        var command = CadastrarCommandFaker.ComEmailInvalido();
        UsuarioRepositoryMock.ConfigurarParaRetornarUsuarioAoObterPorEmail(null);

        // Act
        var resultado = await Handler.Handle(command, default);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Email inválido.");
        UsuarioRepositoryMock.GarantirQueNaoChamouAdicionar();
    }

    [Fact]
    public async Task Handle_QuandoAdicionarRetornaErro_DevePropagarErro()
    {
        // Arrange
        var command = CadastrarCommandFaker.Valido();
        UsuarioRepositoryMock.ConfigurarParaRetornarUsuarioAoObterPorEmail(null);

        var usuario = Usuario.Criar(command.Nome, command.Email, command.Senha).Valor;
        UsuarioRepositoryMock.ConfigurarParaRetornarUsuarioAoAdicionar(Result.Failure<Usuario>("Erro ao adicionar"));

        // Act
        var resultado = await Handler.Handle(command, default);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Erro ao adicionar");
    }
}
