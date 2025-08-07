using TechChallenge.GameStore.Application.Usuarios.Atualizar;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Fixtures;

public class AtualizarHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; private set; }
    protected AtualizarHandler UsuarioHandler { get; private set; }

    public AtualizarHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        UsuarioHandler = new AtualizarHandler(UsuarioRepositoryMock.Object);
    }
}
