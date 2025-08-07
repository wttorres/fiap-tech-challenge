using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechChallenge.GameStore.Domain.Notificacoes;

public interface INotificacaoRepository
{
    void Adicionar(Notificacao notificacao);
    Task<List<int>> ObterUsuariosNaoNotificadosAsync(int promocaoJogoId, List<int> usuarioIds);
    Task SaveChangesAsync();
    Task<List<NotificacaoEnviada>> ObterTodasAsync();
    Task<List<NotificacaoEnviada>> ObterPorUsuarioAsync(int usuarioId);
}