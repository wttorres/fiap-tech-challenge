using MediatR;
using Moq;
using TechChallenge.GameStore.Application.Usuarios.Cadastrar;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Mocks;

public class MediatorMock : Mock<IMediator>
{
    public void ConfigurarSendParaRetornar(Result<string> result)
    {
        Setup(x => x.Send(It.IsAny<CadastrarCommand>(), default))
            .ReturnsAsync(result);
    }

    public void GarantirEnvioDoCommand()
    {
        Verify(x => x.Send(It.IsAny<CadastrarCommand>(), default), Times.Once);
    }
}