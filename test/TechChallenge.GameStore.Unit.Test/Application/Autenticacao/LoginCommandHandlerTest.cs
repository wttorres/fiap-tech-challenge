using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Application.Autenticacao;
using TechChallenge.GameStore.Unit.Test.Application.Autenticacao.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Autenticacao.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Autenticacao;

public class LoginCommandHandlerTest : LoginCommandHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoUsuarioNaoEncontrado_DeveRetornarNull()
    {
        // Arrange
        var command = LoginCommandFaker.Valido("senha123!");
        UsuarioRepositoryMock.ConfigurarObterPorEmailAsyncRetornar(null);

        // Act
        var result = await Handler.Handle(command, default);

        // Assert
        result.Should().BeNull();
        UsuarioRepositoryMock.GarantirObterPorEmailAsyncChamado();
    }

    [Fact]
    public async Task Handle_QuandoSenhaInvalida_DeveRetornarNull()
    {
        // Arrange
        var usuario = UsuarioFaker.ComSenha("senhaCorreta123!");
        UsuarioRepositoryMock.ConfigurarObterPorEmailAsyncRetornar(usuario);

        var command = LoginCommandFaker.ComSenhaIncorreta();

        // Act
        var result = await Handler.Handle(command, default);

        // Assert
        result.Should().BeNull();
        UsuarioRepositoryMock.GarantirObterPorEmailAsyncChamado();
    }

    [Fact]
    public async Task Handle_QuandoCredenciaisValidas_DeveRetornarToken()
    {
        // Arrange
        var senha = "SenhaValida123!";
        var usuario = UsuarioFaker.ComSenha(senha);
        var command = new LoginCommand { Email = usuario.Email, Senha = senha };

        UsuarioRepositoryMock.ConfigurarObterPorEmailAsyncRetornar(usuario);
        JwtTokenServiceMock.ConfigurarGerarTokenRetornar("jwt-fake-token");

        // Act
        var result = await Handler.Handle(command, default);

        // Assert
        result.Should().NotBeNull();
        result!.Token.Should().Be("jwt-fake-token");
        result.Email.Should().Be(usuario.Email);
        result.UsuarioId.Should().Be(usuario.Id);
        result.Perfil.Should().Be(usuario.Perfil.ToString());

        UsuarioRepositoryMock.GarantirObterPorEmailAsyncChamado();
        JwtTokenServiceMock.GarantirGerarTokenChamado();
    }
}
