using System;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Mocks;
using TechChallenge.GameStore.WebApi.Notificacoes.Enviar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Fixtures
{
    public abstract class EnviarNotificacoesJobFixture
    {
        protected MediatorMock MediatorMock { get; private set; }
        protected LoggerMock<EnviarNotificacoesJob> LoggerMock { get; private set; }
        protected IServiceProvider ServiceProvider { get; private set; }
        protected IConfiguration Configuration { get; private set; }

        protected EnviarNotificacoesJob Job { get; private set; }

        protected EnviarNotificacoesJobFixture()
        {
            MediatorMock = new MediatorMock();
            LoggerMock = new LoggerMock<EnviarNotificacoesJob>();
            Configuration = ConfigurationFaker.ComValoresValidos();

            var scope = new Mock<IServiceScope>();
            var scopeFactory = new Mock<IServiceScopeFactory>();
            scope.Setup(x => x.ServiceProvider.GetService(typeof(IMediator))).Returns(MediatorMock.Object);
            scopeFactory.Setup(x => x.CreateScope()).Returns(scope.Object);

            var provider = new Mock<IServiceProvider>();
            provider.Setup(x => x.GetService(typeof(IServiceScopeFactory))).Returns(scopeFactory.Object);
            ServiceProvider = provider.Object;

            Job = new EnviarNotificacoesJob(ServiceProvider, LoggerMock.Object, Configuration);
        }
    }
}