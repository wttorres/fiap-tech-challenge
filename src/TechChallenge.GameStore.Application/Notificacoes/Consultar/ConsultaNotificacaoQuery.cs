using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain.Notificacoes;

namespace TechChallenge.GameStore.Application.Notificacoes.Consultar;

public class ConsultaNotificacaoQuery : IConsultaNotificacaoQuery
{
    private readonly INotificacaoRepository _repository;

    public ConsultaNotificacaoQuery(INotificacaoRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<NotificacaoResponse>> ObterTodasAsync()
    {
        var notificacoes = await _repository.ObterTodasAsync();

        return notificacoes.Any() ? Mapear(notificacoes) : [];
    }

    public async Task<List<NotificacaoResponse>> ObterPorIdUsuarioAsync(int usuarioId)
    {
        var notificacoes = await _repository.ObterPorUsuarioAsync(usuarioId);

        return notificacoes.Any() ? Mapear(notificacoes) : [];
    }
    
    private List<NotificacaoResponse> Mapear(IEnumerable<NotificacaoEnviada> notificacoes)
    {
        return notificacoes.Select(n => new NotificacaoResponse
        {
            Titulo     = n.Notificacao.Titulo,
            Mensagem   = n.Notificacao.Mensagem,
            Jogos      = [n.PromocaoJogo.Jogo.Nome],
            DataInicio = n.PromocaoJogo.Promocao.DataInicio,
            DataFim    = n.PromocaoJogo.Promocao.DataFim
        }).ToList();
    }

}