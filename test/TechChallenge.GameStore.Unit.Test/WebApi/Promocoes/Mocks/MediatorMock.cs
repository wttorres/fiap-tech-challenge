using System;
using System.Threading;
using MediatR;
using Moq;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Mocks;

public class MediatorMock : Mock<IMediator>
{
    public void ConfigurarSend<TRequest, TResponse>(TRequest esperado, TResponse resultado)
        where TRequest : class, IRequest<TResponse>
    {
        Setup(m => m.Send(It.Is<TRequest>(req => req.Equals(esperado)), It.IsAny<CancellationToken>()))
            .ReturnsAsync(resultado);
    }

    public void GarantirSend<TRequest, TResponse>(Func<TRequest, bool> predicado)
        where TRequest : class, IRequest<TResponse>
    {
        Verify(m => m.Send(It.Is<TRequest>(req => predicado(req)), It.IsAny<CancellationToken>()), Times.Once);
    }
}