using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Infrastructure.Autenticacao;

public interface IJwtTokenService
{
    string GerarToken(Usuario usuario);
}