using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechChallenge.GameStore.Application.Notificacoes.Consultar;

public interface IConsultaNotificacaoQuery
{
    Task<List<NotificacaoResponse>> ObterTodasAsync();
    Task<List<NotificacaoResponse>> ObterPorIdUsuarioAsync(int usuarioId);
}