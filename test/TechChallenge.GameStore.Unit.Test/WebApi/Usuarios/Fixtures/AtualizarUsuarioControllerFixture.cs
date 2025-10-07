using TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Mocks;
using TechChallenge.GameStore.WebApi.Usuarios.Atualizar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fixtures;

public abstract class AtualizarUsuarioControllerFixture
{
    protected MediatorMock MediatorMock { get; }
    protected AtualizarUsuarioController Controller { get; }

    protected AtualizarUsuarioControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller = new AtualizarUsuarioController(MediatorMock.Object);
    }
}