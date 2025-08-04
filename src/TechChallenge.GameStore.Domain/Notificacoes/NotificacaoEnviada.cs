using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Domain.Notificacoes;

public class NotificacaoEnviada
{
    public int Id { get; private set; }
    public int UsuarioId { get; private set; }
    public int PromocaoJogoId { get; private set; }
    public int NotificacaoId { get; private set; }

    public Notificacao Notificacao { get; private set; } = null!;
    public Usuario Usuario { get; private set; } = null!;
    public PromocaoJogo PromocaoJogo { get; private set; } = null!;

    private NotificacaoEnviada() { }

    public NotificacaoEnviada(int usuarioId, int promocaoJogoId)
    {
        UsuarioId = usuarioId;
        PromocaoJogoId = promocaoJogoId;
    }
}
