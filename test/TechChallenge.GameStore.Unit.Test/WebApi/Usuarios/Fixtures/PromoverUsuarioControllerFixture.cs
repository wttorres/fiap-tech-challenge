using TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Mocks;
using TechChallenge.GameStore.WebApi.Usuarios.Promover;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fixtures;

public abstract class PromoverUsuarioControllerFixture
{
    protected MediatorMock MediatorMock { get; }
    protected PromoverUsuarioController Controller { get; }

    protected PromoverUsuarioControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller = new PromoverUsuarioController(MediatorMock.Object);
    }
}