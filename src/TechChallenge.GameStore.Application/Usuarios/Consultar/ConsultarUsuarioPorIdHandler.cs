using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Application.Usuarios.Consultar;

public class ConsultarUsuarioPorIdHandler : IRequestHandler<ConsultarUsuarioPorIdQuery, Result<Usuario>>
{
    private readonly IUsuarioRepository _repository;

    public ConsultarUsuarioPorIdHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Usuario>> Handle(ConsultarUsuarioPorIdQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _repository.ObterPorIdAsync(request.Id);
        return usuario is not null
            ? Result.Success(usuario)
            : Result<Usuario>.Failure("Usuário não encontrado");
    }
}