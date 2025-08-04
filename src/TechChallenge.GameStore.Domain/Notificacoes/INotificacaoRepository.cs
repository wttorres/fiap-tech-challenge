namespace TechChallenge.GameStore.Domain.Notificacoes;

public interface INotificacaoRepository
{
    void Adicionar(Notificacao notificacao);
    Task<List<int>> ObterUsuariosNaoNotificadosAsync(int promocaoJogoId, List<int> usuarioIds);
    Task SaveChangesAsync();
}