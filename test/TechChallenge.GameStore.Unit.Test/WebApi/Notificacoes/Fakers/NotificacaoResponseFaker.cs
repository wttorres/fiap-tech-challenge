using System.Collections.Generic;
using System.Linq;
using Bogus;
using TechChallenge.GameStore.Application.Notificacoes.Consultar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Fakers;

public static class NotificacaoResponseFaker
{
    public static NotificacaoResponse Valido()
    {
        return new Faker<NotificacaoResponse>()
            .RuleFor(x => x.Titulo, f => f.Lorem.Sentence())
            .RuleFor(x => x.Mensagem, f => f.Lorem.Paragraph())
            .RuleFor(x => x.Jogos, f => f.Make(3, () => f.Commerce.ProductName()))
            .RuleFor(x => x.DataInicio, f => f.Date.Past())
            .RuleFor(x => x.DataFim, f => f.Date.Future())
            .Generate();
    }

    public static List<NotificacaoResponse> ListaValida(int quantidade = 1)
    {
        return Enumerable.Range(0, quantidade)
            .Select(_ => Valido())
            .ToList();
    }
}