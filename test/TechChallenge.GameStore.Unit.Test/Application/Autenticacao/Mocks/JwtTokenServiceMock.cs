using Moq;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure.Autenticacao;

namespace TechChallenge.GameStore.Unit.Test.Application.Autenticacao.Mocks;

public class JwtTokenServiceMock : Mock<IJwtTokenService>
{
    public void ConfigurarGerarTokenRetornar(string token)
    {
        Setup(s => s.GerarToken(It.IsAny<Usuario>()))
            .Returns(token);
    }

    public void GarantirGerarTokenChamado()
    {
        Verify(s => s.GerarToken(It.IsAny<Usuario>()), Times.Once);
    }
}