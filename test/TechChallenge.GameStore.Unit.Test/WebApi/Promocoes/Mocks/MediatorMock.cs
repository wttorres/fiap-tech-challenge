using MediatR;
using Moq;
using TechChallenge.GameStore.Application.Promocoes.Cadastar;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Mocks;

public class MediatorMock : Mock<IMediator>
{
    public void ConfigurarEnvio(CadastrarPromocaoCommand comando, Result<string> resultado)
    {
        Setup(m => m.Send(comando, default)).ReturnsAsync(resultado);
    }

    public void GarantirEnvio(CadastrarPromocaoCommand comando)
    {
        Verify(m => m.Send(comando, default), Times.Once);
    }
}