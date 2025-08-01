using TechChallenge.GameStore.Application.Usuarios.Cadastrar;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Fixtures;

public class CadastrarHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; private set; }
    protected CadastrarUsuarioHandler UsuarioHandler { get; private set; }

    public CadastrarHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        UsuarioHandler = new CadastrarUsuarioHandler(UsuarioRepositoryMock.Object);
    }
}