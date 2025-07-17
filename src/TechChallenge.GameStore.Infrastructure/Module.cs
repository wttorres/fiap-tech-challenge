using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.GameStore.Domain.Repositories;
using TechChallenge.GameStore.Domain.Repositories.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Repositories;
using TechChallenge.GameStore.Infrastructure.Repositories.Usuarios;

namespace TechChallenge.GameStore.Infrastructure;

public static class Module
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services, configuration);
    }
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<GameStoreContext>(options =>
            options.UseNpgsql(connectionString));
    }
    
    private static void AddRepositories(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }

}