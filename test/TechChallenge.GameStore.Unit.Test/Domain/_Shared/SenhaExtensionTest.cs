using System;
using FluentAssertions;
using TechChallenge.GameStore.Domain._Shared;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Domain._Shared;

public class SenhaExtensionTest
{
    [Theory]
    [InlineData(null, "Senha é obrigatória.")]
    [InlineData("", "Senha é obrigatória.")]
    [InlineData("1234567!", "Senha deve conter pelo menos uma letra.")]
    [InlineData("Abcdefg!", "Senha deve conter pelo menos um número.")]
    [InlineData("Abc12345", "Senha deve conter pelo menos um caractere especial.")]
    [InlineData("Abc@123456", "Senha deve conter no máximo 8 caracteres.")]
    public void ValidarSenha_QuandoInvalida_DeveRetornarErro(string senha, string mensagemEsperada)
    {
        // Act
        var resultado = SenhaExtension.ValidarSenha(senha);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be(mensagemEsperada);
    }

    [Theory]
    [InlineData("Abc@123")]
    [InlineData("1a!2b@3")]
    [InlineData("A1@aaaa")]
    public void ValidarSenha_QuandoValida_DeveRetornarSucesso(string senhaValida)
    {
        // Act
        var resultado = SenhaExtension.ValidarSenha(senhaValida);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().BeTrue();
    }

    [Theory]
    [InlineData("minhaSenha123")]
    [InlineData("Outra@Senha")]
    public void GerarHash_DeveRetornarHashBase64(string senha)
    {
        // Act
        var hash = SenhaExtension.GerarHash(senha);

        // Assert
        hash.Should().NotBeNullOrWhiteSpace();

        var decoded = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(hash));
        decoded.Should().Be(senha);
    }
}