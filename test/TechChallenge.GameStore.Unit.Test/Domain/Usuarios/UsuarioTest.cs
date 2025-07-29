using FluentAssertions;
using TechChallenge.GameStore.Domain.Usuarios;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Domain.Usuarios;

public class UsuarioTest
{
    [Fact]
    public void Criar_QuandoDadosValidos_DeveRetornarSucesso()
    {
        // Arrange
        var nome = "João da Silva";
        var email = "joao@email.com";
        var senha = "Abc@1234";

        // Act
        var resultado = Usuario.Criar(nome, email, senha);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().NotBeNull();
        resultado.Valor!.Nome.Should().Be(nome);
        resultado.Valor.Email.Should().Be(email.ToLower());
        resultado.Valor.Senha.Should().NotBe(senha); 
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Criar_QuandoNomeInvalido_DeveRetornarErro(string nomeInvalido)
    {
        // Arrange
        var email = "teste@email.com";
        var senha = "Abc@1234";

        // Act
        var resultado = Usuario.Criar(nomeInvalido, email, senha);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Nome é obrigatório.");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("emailinvalido.com")]
    [InlineData("teste.com")]
    public void Criar_QuandoEmailInvalido_DeveRetornarErro(string emailInvalido)
    {
        // Arrange
        var nome = "João";
        var senha = "Abc@1234";

        // Act
        var resultado = Usuario.Criar(nome, emailInvalido, senha);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Email inválido.");
    }

    [Theory]
    [InlineData(null, "Senha é obrigatória.")]
    [InlineData("", "Senha é obrigatória.")]
    [InlineData("1234567!", "Senha deve conter pelo menos uma letra.")]
    [InlineData("Abcdefg!", "Senha deve conter pelo menos um número.")]
    [InlineData("Abc12345", "Senha deve conter pelo menos um caractere especial.")]
    [InlineData("Abc@123", "Senha deve conter no mínimo 8 caracteres.")]
    public void Criar_QuandoSenhaInvalida_DeveRetornarErro(string senha, string mensagemEsperada)
    {
        // Arrange
        var nome = "João";
        var email = "joao@email.com";

        // Act
        var resultado = Usuario.Criar(nome, email, senha);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be(mensagemEsperada);
    }

    [Fact]
    public void Atualizar_QuandoNomeEhValido_DeveAtualizarComSucesso()
    {
        // Arrange
        var nome = "João da Silva";
        var email = "joao@email.com";
        var senha = "Abc@1234";

        var usuario = Usuario.Criar(nome, email, senha).Valor;

        var resultado = usuario.Atualizar("Novo Nome", null);
    }

    [Fact]
    public void Atualizar_QuandoSenhaEhValida_DeveAtualizarComSucesso()
    {
        var usuario = Usuario.Criar("Fulano", "fulano@email.com", "Senha12!").Valor;

        var resultado = usuario.Atualizar(null, "NovaSenha1!");

        resultado.Sucesso.Should().BeTrue();
    }

    [Theory]
    [InlineData(null, "Informe ao menos o e-mail ou a senha para atualizar.")]
    [InlineData("", "Informe ao menos o e-mail ou a senha para atualizar.")]
    [InlineData("1234567!", "Senha deve conter pelo menos uma letra.")]
    [InlineData("Abcdefg!", "Senha deve conter pelo menos um número.")]
    [InlineData("Abc12345", "Senha deve conter pelo menos um caractere especial.")]
    [InlineData("Abc@123", "Senha deve conter no mínimo 8 caracteres.")]
    public void Atualizar_QuandoSenhaEhInvalida_DeveRetornarErro(string senha, string mensagemEsperada)
    {
        var usuario = Usuario.Criar("Fulano", "fulano@email.com", "Senha12!").Valor;

        var resultado = usuario.Atualizar(null, senha);

        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be(mensagemEsperada);
    }
}
