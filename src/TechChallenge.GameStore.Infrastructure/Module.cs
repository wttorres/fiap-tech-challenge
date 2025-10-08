using System;
using System.Diagnostics.CodeAnalysis;
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

[ExcludeFromCodeCoverage]
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
        var fromEnvJwtIssuer   = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? configuration["JWT_ISSUER"];
        var fromEnvJwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? configuration["JWT_AUDIENCE"];
        var fromEnvJwtKey      = Environment.GetEnvironmentVariable("JWT_KEY") ?? configuration["JWT_KEY"];
        
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer   = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer              = fromEnvJwtIssuer,
                    ValidAudience            = fromEnvJwtAudience,
                    IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(fromEnvJwtKey!))
                };
            });

        services.AddAuthorization();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var fromEnv          = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");
        var fromConfig       = configuration["CONNECTION_STRING"];
        var connectionString = !string.IsNullOrWhiteSpace(fromEnv) ? fromEnv : fromConfig;

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