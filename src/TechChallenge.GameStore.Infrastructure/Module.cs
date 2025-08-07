using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Notificacoes;
using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Compras;
using TechChallenge.GameStore.Infrastructure.Jogos;
using TechChallenge.GameStore.Infrastructure.Notificacoes;
using TechChallenge.GameStore.Infrastructure.Promocoes;
using TechChallenge.GameStore.Infrastructure.Usuarios;

namespace TechChallenge.GameStore.Infrastructure;

public static class Module
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        
        services.AddScoped<IEmailSender, EmailSender>();
    }
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<GameStoreContext>(options =>
            options.UseNpgsql(connectionString));
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IPromocaoRepository, PromocaoRepository>();
        services.AddScoped<IJogoRepository, JogoRepository>();
        services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
        services.AddScoped<IHistoricoCompraRepository, HistoricoCompraRepository>();
        services.AddScoped<IBibliotecaJogosRepository, BibliotecaJogosRepository>();
    }
}