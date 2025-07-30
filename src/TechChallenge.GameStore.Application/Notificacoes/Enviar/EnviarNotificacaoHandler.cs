using MediatR;
using TechChallenge.GameStore.Domain.Notificacoes;
using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Application.Notificacoes.Enviar;

public class EnviarNotificacaoHandler : IRequestHandler<EnviarNotificacaoCommand>
{
    private readonly IPromocaoRepository _promocaoRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly INotificacaoRepository _notificacaoRepository;
    private readonly IEmailSender _emailSender;

    public EnviarNotificacaoHandler(
        IPromocaoRepository promocaoRepository,
        IUsuarioRepository usuarioRepository,
        INotificacaoRepository notificacaoRepository,
        IEmailSender emailSender)
    {
        _promocaoRepository = promocaoRepository;
        _usuarioRepository = usuarioRepository;
        _notificacaoRepository = notificacaoRepository;
        _emailSender = emailSender;
    }

    public async Task Handle(EnviarNotificacaoCommand request, CancellationToken cancellationToken)
    {
        var usuarios  = await _usuarioRepository.ObterUsuariosQueRecebemNotificacoesAsync();

        if (usuarios.Count == 0) return;
        
        var promocoes = await _promocaoRepository.ObterPromocoesAtivasComJogosAsync();

        if (promocoes.Count != 0)
        {
            await NotificarPromocoesAsync(promocoes, usuarios);
        };
    }

    private async Task NotificarPromocoesAsync(List<Promocao> promocoes, List<Usuario> usuarios)
    { 
        foreach (var promocao in promocoes)
        {
            foreach (var pj in promocao.Jogos)
            {
                var usuariosNaoNotificados = await _notificacaoRepository
                    .ObterUsuariosNaoNotificadosAsync(pj.Id, usuarios.Select(u => u.Id).ToList());

                if (!usuariosNaoNotificados.Any()) continue;

                var notificacao = Notificacao.Criar(pj.Jogo, promocao);

                foreach (var usuarioId in usuariosNaoNotificados)
                {
                    var usuario = usuarios.First(u => u.Id == usuarioId);
                    await _emailSender.EnviarAsync(usuario.Email, notificacao.Titulo, notificacao.Mensagem);
                    notificacao.AdicionarEnvio(usuarioId, pj.Id);
                }

                _notificacaoRepository.Adicionar(notificacao);
            }
        }

        if (promocoes.Count != 0) 
            await _notificacaoRepository.SaveChangesAsync();
    }
}