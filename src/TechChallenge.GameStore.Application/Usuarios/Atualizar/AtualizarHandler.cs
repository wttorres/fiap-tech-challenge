using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Application.Usuarios.Atualizar;

public class AtualizarHandler :IRequestHandler<AtualizarCommand, Result<string>>
{
    private readonly IUsuarioRepository _repository;

    public AtualizarHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(AtualizarCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _repository.ObterPorIdAsync(request.Id);
        if (usuario is null)
            return Result.Failure<string>($"Usuário com ID {request.Id} não encontrado.");

        var result = usuario.Atualizar(request?.Nome, request?.Senha);
        if (!result.Sucesso)
            return Result.Failure<string>(result.Erro);

        var salvar = await _repository.AtualizarAsync(result.Valor);
        return salvar.Sucesso
            ? Result.Success("Usuário atualizado com sucesso")
            : Result.Failure<string>(salvar.Erro);
    }   
}
