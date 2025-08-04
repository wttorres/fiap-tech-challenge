using TechChallenge.GameStore.Application.Autenticacao;
using TechChallenge.GameStore.Unit.Test.Application.Autenticacao.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Autenticacao.Fixtures;

public class LoginCommandHandlerFixture
{
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; private set; }
    protected JwtTokenServiceMock JwtTokenServiceMock { get; private set; }

    protected LoginCommandHandler Handler { get; private set; }

    protected LoginCommandHandlerFixture()
    {
        UsuarioRepositoryMock = new UsuarioRepositoryMock();
        JwtTokenServiceMock = new JwtTokenServiceMock();

        Handler = new LoginCommandHandler(
            UsuarioRepositoryMock.Object,
            JwtTokenServiceMock.Object
        );
    }
}