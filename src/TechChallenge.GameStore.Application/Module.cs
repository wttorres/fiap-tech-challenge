using Microsoft.Extensions.DependencyInjection;
using TechChallenge.GameStore.Application.Jogos.Consultar;
using TechChallenge.GameStore.Application.Notificacoes.Consultar;
using TechChallenge.GameStore.Application.Promocoes.Consultar;

namespace TechChallenge.GameStore.Application;

public static class Module
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining(typeof(Module)));

        services.AddScoped<IConsultaPromocaoQuery, ConsultaPromocaoQuery>();
        services.AddScoped<IConsultaNotificacaoQuery, ConsultaNotificacaoQuery>();
        services.AddScoped<IConsultaJogoQuery, ConsultaJogoQuery>();
    }
}