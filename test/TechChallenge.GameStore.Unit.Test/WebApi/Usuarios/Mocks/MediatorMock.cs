using MediatR;
using Moq;
using TechChallenge.GameStore.Application.Usuarios.Atualizar;
using TechChallenge.GameStore.Application.Usuarios.Cadastrar;
using TechChallenge.GameStore.Application.Usuarios.Promover;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Mocks;

public class MediatorMock : Mock<IMediator>
{
    public void ConfigurarCadastroSendParaRetornar(Result<string> result)
    {
        Setup(x => x.Send(It.IsAny<CadastrarUsuarioCommand>(), default))
            .ReturnsAsync(result);
    }

    public void GarantirEnvioDoCadastroCommand()
    {
        Verify(x => x.Send(It.IsAny<CadastrarUsuarioCommand>(), default), Times.Once);
    }
    
    public void ConfigurarAtualizaSendParaRetornar(Result<string> result)
    {
        Setup(x => x.Send(It.IsAny<AtualizarCommand>(), default))
            .ReturnsAsync(result);
    }

    public void GarantirEnvioDoAtualizaCommand()
    {
        Verify(x => x.Send(It.IsAny<AtualizarCommand>(), default), Times.Once);
    }
    
    public void ConfigurarPromoveSendParaRetornar(Result<string> result)
    {
        Setup(x => x.Send(It.IsAny<PromoverUsuarioCommand>(), default))
            .ReturnsAsync(result);
    }

    public void GarantirEnvioDoPromoveCommand()
    {
        Verify(x => x.Send(It.IsAny<PromoverUsuarioCommand>(), default), Times.Once);
    }
}