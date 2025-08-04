using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Fixtures;
using TechChallenge.GameStore.WebApi.Notificacoes.Enviar;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes
{
    public class EnviarNotificacoesJobTest : EnviarNotificacoesJobFixture
    {
        [Fact]
        public async Task ExecuteAsync_QuandoExecutado_DeveEnviarNotificacao()
        {
            // Arrange
            MediatorMock.ConfigurarEnvioComSucesso();
            using var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(100); 

            // Act
            await Job.StartAsync(tokenSource.Token);

            // Assert
            MediatorMock.GarantirEnvioRealizado();
        }

        [Fact]
        public void ObterIntervalo_QuandoIntervaloValido_DeveRetornarIntervaloEsperado()
        {
            // Arrange
            var intervalo = typeof(EnviarNotificacoesJob)
                .GetMethod("ObterIntervalo", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .Invoke(Job, null);

            // Assert
            intervalo.Should().Be(TimeSpan.FromMinutes(1));
        }

        [Fact]
        public void ObterIntervalo_QuandoInvalido_DeveRetornarIntervaloPadrao()
        {
            // Arrange
            var jobComInvalido = new EnviarNotificacoesJob(ServiceProvider, LoggerMock.Object, ConfigurationFaker.ComIntervaloInvalido());

            // Act
            var intervalo = typeof(EnviarNotificacoesJob)
                .GetMethod("ObterIntervalo", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .Invoke(jobComInvalido, null);

            // Assert
            intervalo.Should().Be(TimeSpan.FromMinutes(60));
        }
    }
}