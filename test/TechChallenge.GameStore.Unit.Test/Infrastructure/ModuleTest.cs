using System.Collections.Generic;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Usuarios;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure;

public class ModuleTest
{
    [Fact]
    public void AddInfrastructure_DeveRegistrarRepositoriosCorretamente_ComDbContextSimulado()
    {
        // Arrange
        var services = new ServiceCollection();

        var inMemorySettings = new Dictionary<string, string?>
        {
            { "ConnectionStrings:DefaultConnection", "fake-conn" }
        };

        new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        // Substitui temporariamente AddDbContext real
        services.AddDbContext<GameStoreContext>(opt => opt.UseInMemoryDatabase("test-db"));

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        // Act
        var provider = services.BuildServiceProvider();

        // Assert
        var context = provider.GetService<GameStoreContext>();
        context.Should().NotBeNull();

        var repo = provider.GetService<IUsuarioRepository>();
        repo.Should().NotBeNull();
        repo.Should().BeOfType<UsuarioRepository>();
    }
}