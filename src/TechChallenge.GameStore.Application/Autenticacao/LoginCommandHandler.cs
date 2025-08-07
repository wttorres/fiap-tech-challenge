using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure.Autenticacao;

namespace TechChallenge.GameStore.Application.Autenticacao;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse?>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public LoginCommandHandler(IUsuarioRepository usuarioRepository, IJwtTokenService jwtTokenService)
    {
        _usuarioRepository = usuarioRepository;
        _jwtTokenService   = jwtTokenService;
    }

    public async Task<LoginResponse?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);
        if (usuario is null) return null;

        if (!SenhaExtension.Comparar(request.Senha, usuario.Senha))
            return null;

        var token = _jwtTokenService.GerarToken(usuario);

        return new LoginResponse
        {
            UsuarioId = usuario.Id,
            Email = usuario.Email,
            Perfil = usuario.Perfil.ToString(),
            Token = token
        };
    }
}