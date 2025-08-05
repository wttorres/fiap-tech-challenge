using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Application.Usuarios.Consultar;

public class ConsultarUsuarioPorIdQuery : IRequest<Result<Usuario>>
{
    public int Id { get; set; }
}