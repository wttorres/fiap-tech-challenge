using Microsoft.Extensions.Configuration;
using Moq;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Autenticacao.Mocks;

public class ConfigurationMock : Mock<IConfiguration>
{
    public void ConfigurarValoresPadroesJwt()
    {
        Setup(c => c["JWT_KEY"]).Returns("chave-secreta-super-segura-para-testes");
        Setup(c => c["JWT_ISSUER"]).Returns("GameStore.Issuer.Teste");
        Setup(c => c["JWT_AUDIENCE"]).Returns("GameStore.Audience.Teste");
    }
}