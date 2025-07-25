using MediatR;
using Moq;
using TechChallenge.GameStore.Application.Jogos.Cadastrar;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Jogos.Mocks;

public class MediatorMockJogos : Mock<IMediator>
{
    public void ConfigurarEnvio(CadastrarJogoCommand comando, Result<string> resultado)
    {
        Setup(m => m.Send(comando, default)).ReturnsAsync(resultado);
    }

    public void GarantirEnvio(CadastrarJogoCommand comando)
    {
        Verify(m => m.Send(comando, default), Times.Once);
    }
}
