using MediatR;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Application.Usuarios.Cadastrar;

public class CadastrarCommand : IRequest<Result<string>>
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}