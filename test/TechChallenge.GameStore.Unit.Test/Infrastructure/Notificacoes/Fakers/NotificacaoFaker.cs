using TechChallenge.GameStore.Domain.Notificacoes;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Notificacoes.Fakers;

public static class NotificacaoFaker
{
    public static Notificacao Valida()
    {
        var jogo = JogoFaker.Valido();
        var promocao = PromocaoFaker.Valida();
        return Notificacao.Criar(jogo, promocao);
    }
}