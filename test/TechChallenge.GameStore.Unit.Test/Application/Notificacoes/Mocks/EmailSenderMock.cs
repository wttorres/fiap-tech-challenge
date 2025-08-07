using System.Threading.Tasks;
using Moq;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Mocks;

public class EmailSenderMock : Mock<IEmailSender>
{
    public void ConfigurarEnvioEmail()
    {
        Setup(s => s.EnviarAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(Task.CompletedTask);
    }

    public void GarantirEnvioEmail(int vezes)
    {
        Verify(s => s.EnviarAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Exactly(vezes));
    }
}