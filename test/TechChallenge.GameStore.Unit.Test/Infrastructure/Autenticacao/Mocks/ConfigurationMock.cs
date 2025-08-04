using Microsoft.Extensions.Configuration;
using Moq;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Autenticacao.Mocks;

public class ConfigurationMock : Mock<IConfiguration>
{
    public void ConfigurarValoresPadroesJwt()
    {
        Setup(c => c["Jwt:Key"]).Returns("chave-secreta-super-segura-para-testes");
        Setup(c => c["Jwt:Issuer"]).Returns("GameStore.Issuer.Teste");
        Setup(c => c["Jwt:Audience"]).Returns("GameStore.Audience.Teste");
    }

    public string ObterChave() => "chave-secreta-super-segura-para-testes";
}