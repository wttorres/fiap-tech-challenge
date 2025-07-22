using System.Collections.Generic;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Usuarios;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi;

public class ModuleTest
{
    [Fact]
    public void AddInfrastructure_QuandoChamado_DeveRegistrarContextoERepositorios()
    {
        // Arrange
        var services = new ServiceCollection();

        // Simula configuração
        var configValues = new Dictionary<string, string>
        {
            { "ConnectionStrings:DefaultConnection", "fake-connection-string" }
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configValues!)
            .Build();

        services.AddDbContext<GameStoreContext>(opt => opt.UseInMemoryDatabase("TestDb"));

        var addRepositoriesMethod = typeof(TechChallenge.GameStore.Infrastructure.Module)
            .GetMethod("AddRepositories", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

        addRepositoriesMethod!.Invoke(null, [services, configuration]);

        // Act
        var provider = services.BuildServiceProvider();

        // Assert
        provider.GetService<GameStoreContext>().Should().NotBeNull();
        var repo = provider.GetService<IUsuarioRepository>();
        repo.Should().NotBeNull();
        repo.Should().BeOfType<UsuarioRepository>();
    }
}