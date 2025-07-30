using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.GameStore.Application.Jogos.Consultar;
using TechChallenge.GameStore.Application.Promocoes.Consultar;
using TechChallenge.GameStore.Application.Compras.Consultar;

namespace TechChallenge.GameStore.Application;

public static class Module
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining(typeof(Module)));

        services.AddScoped<IConsultaPromocaoQuery, ConsultaPromocaoQuery>();
        services.AddScoped<IConsultaJogoQuery, ConsultaJogoQuery>();
    }
}