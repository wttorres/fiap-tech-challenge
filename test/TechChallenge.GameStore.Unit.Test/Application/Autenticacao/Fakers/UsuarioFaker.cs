using AutoBogus;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Application.Autenticacao.Fakers;


public static class UsuarioFaker
{
    public static Usuario ComSenha(string senha)
    {
        var senhaHash = SenhaExtension.GerarHash(senha);

        return new AutoFaker<Usuario>()
            .RuleFor(x => x.Senha, senhaHash)
            .Generate();
    }
}