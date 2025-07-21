using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TechChallenge.GameStore.Application;
using TechChallenge.GameStore.Application.Usuarios.Cadastrar;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application;

public class ModuleRegistrationTest
{
    [Fact]
    public void AddApplication_DeveRegistrarMediatRComHandlers()
    {
        // Arrange
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();
        var usuarioRepoMock = new Mock<IUsuarioRepository>();
        services.AddScoped(_ => usuarioRepoMock.Object);

        // Act
        services.AddApplication(configuration);
        var provider = services.BuildServiceProvider();

        // Assert 
        var mediator = provider.GetService<IMediator>();
        mediator.Should().NotBeNull();
        
        var handler = provider.GetService<IRequestHandler<CadastrarCommand, Result<string>>>();
        handler.Should().NotBeNull();
        handler.Should().BeOfType<CadastrarHandler>();
    }
}