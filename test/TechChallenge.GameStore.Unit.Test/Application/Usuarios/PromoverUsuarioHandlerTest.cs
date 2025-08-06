using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TechChallenge.GameStore.Application.Usuarios.Promover;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Promover;

public class PromoverUsuarioHandlerTest
{
    private readonly Mock<IUsuarioRepository> _repositoryMock;
    private readonly PromoverUsuarioHandler _handler;

    public PromoverUsuarioHandlerTest()
    {
        _repositoryMock = new Mock<IUsuarioRepository>();
        _handler = new PromoverUsuarioHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Deve_Promover_Usuario_Com_Sucesso()
    {
        //Arrange
        var usuario = Usuario.Criar("Joao da Silva", "teste@email.com", "Abc@12345").Valor;
        
        _repositoryMock
            .Setup(x => x.ObterPorIdAsync(usuario.Id))
            .ReturnsAsync(usuario);
        _repositoryMock
            .Setup(x => x.AtualizarAsync(usuario))
            .ReturnsAsync(Result<Usuario>.Success(usuario));

        var command = new PromoverUsuarioCommand
        {
            Id = usuario.Id,
            NovoPerfil = Perfil.Admin
        };
        
        //Act
        var resultado = await _handler.Handle(command, default);
        
        //Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().Be("Usuário promovido com sucesso");
    }

    [Fact]
    public async Task Nao_Deve_Promover_Usuario_Inexistente()
    {
        //Arrange
        _repositoryMock
            .Setup(x => x.ObterPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Usuario)null);

        var command = new PromoverUsuarioCommand
        {
            Id = 999999,
            NovoPerfil = Perfil.Admin
        };
        
        //Act
        var resultado = await _handler.Handle(command, default);
        
        //Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Usuário não encontrado.");
    }

    [Fact]
    public async Task Nao_Deve_Promover_Para_Perfil_Invalido()
    {
        //Arrange
        var usuario = Usuario.Criar("Joao da Silva", "teste@email.com", "Abc@12345").Valor;
        
        _repositoryMock
            .Setup(x => x.ObterPorIdAsync(usuario.Id))
            .ReturnsAsync(usuario);

        var command = new PromoverUsuarioCommand
        {
            Id = usuario.Id,
            NovoPerfil = (Perfil)999
        };
        
        //Act
        var resultado = await _handler.Handle(command, default);
        
        //Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Perfil inválido.");
    }
}