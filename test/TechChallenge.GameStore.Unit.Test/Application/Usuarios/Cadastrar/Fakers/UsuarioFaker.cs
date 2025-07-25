using AutoBogus;
using TechChallenge.GameStore.Application.Usuarios.Cadastrar;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Cadastrar.Fakers;

public class UsuarioFaker
{
    public static Usuario ConverterParaUsuario(CadastrarUsuarioCommand command)
    {
        return new AutoFaker<Usuario>()
            .RuleFor(x => x.Nome, f => command.Nome)
            .RuleFor(x => x.Email, f => command.Email)
            .RuleFor(x => x.Senha, f => command.Senha)
            .Generate();
    }
}