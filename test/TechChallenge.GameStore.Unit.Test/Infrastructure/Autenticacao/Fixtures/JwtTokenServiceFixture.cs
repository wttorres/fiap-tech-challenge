using TechChallenge.GameStore.Infrastructure.Autenticacao;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Autenticacao.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Autenticacao.Fixtures;

public class JwtTokenServiceFixture
{
    protected ConfigurationMock ConfigurationMock { get; private set; }
    protected JwtTokenService TokenService { get; private set; }

    protected JwtTokenServiceFixture()
    {
        ConfigurationMock = new ConfigurationMock();
        ConfigurationMock.ConfigurarValoresPadroesJwt();

        TokenService = new JwtTokenService(ConfigurationMock.Object);
    }
}