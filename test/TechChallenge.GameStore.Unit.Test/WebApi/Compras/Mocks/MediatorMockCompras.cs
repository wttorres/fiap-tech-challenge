using MediatR;
using Moq;
using TechChallenge.GameStore.Application.Compras.Comprar;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras.Mocks;

public class MediatorMockCompras : Mock<IMediator>
{
    public void ConfigurarEnvio(ComprarJogoCommand comando, Result<string> resultado)
    {
        Setup(m => m.Send(comando, default)).ReturnsAsync(resultado);
    }

    public void GarantirEnvio(ComprarJogoCommand comando)
    {
        Verify(m => m.Send(comando, default), Times.Once);
    }
}
