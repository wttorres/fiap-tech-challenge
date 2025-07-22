using FluentAssertions;
using TechChallenge.GameStore.Domain._Shared;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Domain._Shared;

public class ResultTest
{
    [Fact]
    public void Success_QuandoValorEhValido_DeveCriarObjetoComSucesso()
    {
        // Arrange
        var valor = "valor esperado";

        // Act
        var resultado = Result.Success(valor);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Erro.Should().BeNull();
        resultado.Valor.Should().Be(valor);
    }

    [Fact]
    public void Failure_QuandoErroEhFornecido_DeveCriarObjetoComFalha()
    {
        // Arrange
        var mensagemErro = "ocorreu um erro";

        // Act
        var resultado = Result.Failure<string>(mensagemErro);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be(mensagemErro);
        resultado.Valor.Should().BeNull();
    }

    [Fact]
    public void Failure_QuandoUsandoTipoInt_DeveRetornarValorDefault()
    {
        // Arrange
        var erro = "erro numérico";

        // Act
        var resultado = Result.Failure<int>(erro);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be(erro);
        resultado.Valor.Should().Be(default(int)); // 0
    }

    [Fact]
    public void Success_QuandoUsandoTipoComplexo_DeveRetornarObjeto()
    {
        // Arrange
        var objeto = new { Nome = "Item", Valor = 10 };

        // Act
        var resultado = Result.Success(objeto);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().BeEquivalentTo(objeto);
    }
}