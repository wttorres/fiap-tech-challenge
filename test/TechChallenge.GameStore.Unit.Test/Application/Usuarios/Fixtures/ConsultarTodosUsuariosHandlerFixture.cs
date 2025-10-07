using TechChallenge.GameStore.Application.Usuarios.Consultar;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Fixtures;

public abstract class ConsultarTodosUsuariosHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; }
    protected ConsultarTodosUsuariosHandler Handler { get; }

    protected ConsultarTodosUsuariosHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        Handler = new ConsultarTodosUsuariosHandler(UsuarioRepositoryMock.Object);
    }
}