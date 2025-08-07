using Moq;
using System.Collections.Generic;
using MediatR;
using System.Threading;
using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras.Mocks;

public class MediatorMockBibliotecaJogos : Mock<IMediator>
{
    public void ConfigurarEnvio(ConsultaBibliotecaJogosQuery query, Result<List<JogoAdquiridoResponse>> resultado)
    {
        Setup(m => m.Send(
            It.Is<ConsultaBibliotecaJogosQuery>(q => q.UsuarioId == query.UsuarioId),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(resultado);
    }


    public void GarantirEnvio(ConsultaBibliotecaJogosQuery query)
    {
        Verify(m => m.Send(
            It.Is<ConsultaBibliotecaJogosQuery>(q => q.UsuarioId == query.UsuarioId),
            It.IsAny<CancellationToken>()
        ), Times.Once);
    }

}
