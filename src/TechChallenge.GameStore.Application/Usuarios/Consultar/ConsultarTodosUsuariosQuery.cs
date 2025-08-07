using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Application.Usuarios.Consultar;

public class ConsultarTodosUsuariosQuery : IRequest<Result<List<Usuario>>> { }