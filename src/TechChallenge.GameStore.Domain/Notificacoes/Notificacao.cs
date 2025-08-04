using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Domain.Notificacoes;

public class Notificacao
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Mensagem { get; private set; }
    public DateTime DataEnvio { get; private set; }

    public List<NotificacaoEnviada> Enviadas { get; private set; } = new();

    private Notificacao() { }

    private Notificacao(string titulo, string mensagem)
    {
        Titulo = titulo;
        Mensagem = mensagem;
        DataEnvio = DateTime.UtcNow;
    }

    public static Notificacao Criar(Jogo jogo, Promocao promocao)
    {
        var titulo = $"Promoção: {promocao.Nome}!";
        var mensagem = $"O jogo {jogo.Nome} está com {promocao.DescontoPercentual}% de desconto!";
        return new Notificacao(titulo, mensagem);
    }

    public void AdicionarEnvio(int usuarioId, int promocaoJogoId)
    {
        Enviadas.Add(new NotificacaoEnviada(usuarioId, promocaoJogoId));
    }
}