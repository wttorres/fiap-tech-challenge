using TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Mocks;
using TechChallenge.GameStore.WebApi.Usuarios.Cadastrar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fixtures;

public class CadastrarUsuarioControllerFixture
{
    protected MediatorMock MediatorMock { get; private set; }
    protected CadastrarUsuarioController Controller { get; private set; }

    public CadastrarUsuarioControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller = new CadastrarUsuarioController(MediatorMock.Object);
    }
}