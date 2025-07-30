using Microsoft.Extensions.Logging;
using Moq;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Mocks;

public class LoggerMock<T> : Mock<ILogger<T>>;
