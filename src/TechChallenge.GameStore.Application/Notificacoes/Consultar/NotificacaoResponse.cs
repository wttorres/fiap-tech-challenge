using System;
using System.Collections.Generic;

namespace TechChallenge.GameStore.Application.Notificacoes.Consultar;

public class NotificacaoResponse
{
    public string? Titulo { get; init; }
    public string? Mensagem { get; init; }
    public List<string>? Jogos { get; init; }
    public DateTime DataInicio { get; init; }
    public DateTime DataFim { get; init; }
}