using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Application.Usuarios.Promover;

public class PromoverUsuarioHandler : IRequestHandler<PromoverUsuarioCommand, Result<string>>
{
    private readonly IUsuarioRepository _repository;

    public PromoverUsuarioHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(PromoverUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _repository.ObterPorIdAsync(request.Id);
        if (usuario is null)
            return Result.Failure<string>("Usuário não encontrado.");

        var resultado = usuario.AtualizarPerfil(request.NovoPerfil);

        if (!resultado.Sucesso)
            return Result.Failure<string>(resultado.Erro);

        var atualizar = await _repository.AtualizarAsync(usuario);

        return atualizar.Sucesso
            ? Result.Success("Usuário promovido com sucesso")
            : Result.Failure<string>(atualizar.Erro);
    }
}
