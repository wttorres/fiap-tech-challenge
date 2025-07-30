using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Application.Usuarios.Atualizar;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios;

public class AtualizarHandlerTest : AtualizarHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoNomeEhValido_DeveAtualizarComSucesso()
    {
        //Arrange
        var command = CadastrarCommandFaker.Valido();
        var usuario = Usuario.Criar(command.Nome, command.Email, command.Senha).Valor;
        var novoNome = "Fulano Junior";

        UsuarioRepositoryMock.ConfigurarParaObterPorId(usuario);
        UsuarioRepositoryMock.ConfigurarParaAtualizar(Result.Success(usuario));

        var commandAtualizar = new AtualizarCommand
        {
            Id = usuario.Id,
            Nome = novoNome,
        };

        //Act
        var result = await UsuarioHandler.Handle(commandAtualizar, default);

        //Assert
        result.Sucesso.Should().BeTrue();
        result.Valor.Should().Be("Usuário atualizado com sucesso");
        usuario.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task Handle_QuandoSenhaEhValida_DeveAtualizarComSucesso()
    {
        //Arrange
        var command = CadastrarCommandFaker.Valido();
        var usuario = Usuario.Criar(command.Nome, command.Email, command.Senha).Valor;
        var novaSenha = "NovaSenha!@12";

        UsuarioRepositoryMock.ConfigurarParaObterPorId(usuario);
        UsuarioRepositoryMock.ConfigurarParaAtualizar(Result.Success(usuario));


        var commandAtualizar = new AtualizarCommand
        {
            Id = usuario.Id,
            Senha = novaSenha,
        };

        //Act
        var result = await UsuarioHandler.Handle(commandAtualizar, default);

        //Assert
        result.Sucesso.Should().BeTrue();
        result.Valor.Should().Be("Usuário atualizado com sucesso");
    }

    [Theory]
    [InlineData(null, "Informe ao menos o e-mail ou a senha para atualizar.")]
    [InlineData("", "Informe ao menos o e-mail ou a senha para atualizar.")]
    [InlineData("1234567!", "Senha deve conter pelo menos uma letra.")]
    [InlineData("Abcdefg!", "Senha deve conter pelo menos um número.")]
    [InlineData("Abc12345", "Senha deve conter pelo menos um caractere especial.")]
    [InlineData("Abc@123", "Senha deve conter no mínimo 8 caracteres.")]
    public async Task Handle_QuandoSenhaInvalida_DeveRetornarErro(string senha, string mensagemEsperada)
    {
        //Arrange
        var command = CadastrarCommandFaker.Valido();
        var usuario = Usuario.Criar(command.Nome, command.Email, command.Senha).Valor;

        UsuarioRepositoryMock.ConfigurarParaObterPorId(usuario);

        var commandAtualizar = new AtualizarCommand
        {
            Id = usuario.Id,
            Senha = senha,
        };

        // Act
        var result = await UsuarioHandler.Handle(commandAtualizar, default);

        // Assert
        result.Sucesso.Should().BeFalse();
        result.Erro.Should().Be(mensagemEsperada);
    }
}
