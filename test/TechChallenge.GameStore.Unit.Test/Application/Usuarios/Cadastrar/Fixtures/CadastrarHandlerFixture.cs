using TechChallenge.GameStore.Application.Usuarios.Cadastrar;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar.Fixtures;

public class CadastrarHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; private set; }
    protected CadastrarHandler Handler { get; private set; }

    public CadastrarHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        Handler = new CadastrarHandler(UsuarioRepositoryMock.Object);
    }
}