using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TechChallenge.GameStore.Application.Notificacoes.Enviar;

namespace TechChallenge.GameStore.WebApi.Notificacoes.Enviar;

public class EnviarNotificacoesJob : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<EnviarNotificacoesJob> _logger;
    private readonly IConfiguration _configuration;

    public EnviarNotificacoesJob(
        IServiceProvider serviceProvider,
        ILogger<EnviarNotificacoesJob> logger,
        IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var intervalo = ObterIntervalo();

        _logger.LogInformation("Job de envio de notificações habilitado. Executando a cada {Intervalo} minutos.", intervalo.TotalMinutes);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                await mediator.Send(new EnviarNotificacaoCommand(), stoppingToken);

                _logger.LogInformation("Notificações enviadas com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao enviar notificações.");
            }

            await Task.Delay(intervalo, stoppingToken);
        }
    }

    private TimeSpan ObterIntervalo()
    {
        var intervaloMinStr = _configuration["ENVIA_NOTIFICACAO_INTERVALO_MINUTOS"];

        if (int.TryParse(intervaloMinStr, out var minutos) && minutos > 0)
            return TimeSpan.FromMinutes(minutos);

        _logger.LogWarning("Variável ENVIA_NOTIFICACAO_INTERVALO_MINUTOS inválida. Usando padrão de 60 minutos.");
        return TimeSpan.FromMinutes(60);
    }
}