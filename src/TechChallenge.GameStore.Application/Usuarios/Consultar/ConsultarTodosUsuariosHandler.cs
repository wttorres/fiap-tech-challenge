using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Application.Usuarios.Consultar;

public class ConsultarTodosUsuariosHandler : IRequestHandler<ConsultarTodosUsuariosQuery, Result<List<Usuario>>>
{
    private readonly IUsuarioRepository _repository;

    public ConsultarTodosUsuariosHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<Usuario>>> Handle(ConsultarTodosUsuariosQuery request,
        CancellationToken cancellationToken)
    {
        var usuarios = await _repository.ObterTodosAsync();
        var usuariosOrdenados = usuarios
            .OrderBy(u => u.Id)
            .ToList();
        return Result.Success(usuariosOrdenados);
    }
}