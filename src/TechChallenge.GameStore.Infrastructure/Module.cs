using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TechChallenge.GameStore.Domain.Compras.Interfaces;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Notificacoes;
using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;
using TechChallenge.GameStore.Infrastructure.Autenticacao;
using TechChallenge.GameStore.Infrastructure.Compras.Imp;
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
        AddAuthentication(services, configuration);
        
        services.AddScoped<IEmailSender, EmailSender>();
    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer   = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer              = configuration["Jwt:Issuer"],
                    ValidAudience            = configuration["Jwt:Audience"],
                    IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });

        services.AddAuthorization();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        if(string.IsNullOrWhiteSpace(connectionString))
            connectionString = configuration.GetConnectionString("CONNECTION_STRING");
        if(string.IsNullOrWhiteSpace(connectionString))
            connectionString = configuration.GetConnectionString("POSTGRES_CONNECTION_STRING");
        
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