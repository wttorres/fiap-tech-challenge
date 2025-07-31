using System.Collections.Generic;
using Moq;
using System.Threading;
using MediatR;
using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras.Mocks;

public class ConsultaBibliotecaJogosQueryMock : Mock<IRequestHandler<ConsultaBibliotecaJogosQuery, Result<List<JogoAdquiridoResponse>>>>
{
    public void ConfigurarHandle(ConsultaBibliotecaJogosQuery query, Result<List<JogoAdquiridoResponse>> resultado)
    {
        Setup(x => x.Handle(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(resultado);
    }

    public void GarantirHandleChamado(ConsultaBibliotecaJogosQuery query)
    {
        Verify(x => x.Handle(query, It.IsAny<CancellationToken>()), Times.Once);
    }
}
