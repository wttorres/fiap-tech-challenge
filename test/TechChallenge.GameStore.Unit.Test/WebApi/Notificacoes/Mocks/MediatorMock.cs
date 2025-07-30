using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using TechChallenge.GameStore.Application.Notificacoes.Enviar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Mocks
{
    public class MediatorMock : Mock<IMediator>
    {
        public void ConfigurarEnvioComSucesso()
        {
            Setup(m => m.Send(It.IsAny<EnviarNotificacaoCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
        }

        public void GarantirEnvioRealizado()
        {
            Verify(m => m.Send(It.IsAny<EnviarNotificacaoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}