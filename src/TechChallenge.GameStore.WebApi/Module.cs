using Microsoft.Extensions.DependencyInjection;
using TechChallenge.GameStore.WebApi.Notificacoes.Enviar;

namespace TechChallenge.GameStore.WebApi;

public static class Module
{
    public static void AddWebApi(this IServiceCollection services)
    {
        services.AddHostedService<EnviarNotificacoesJob>();
    }
}