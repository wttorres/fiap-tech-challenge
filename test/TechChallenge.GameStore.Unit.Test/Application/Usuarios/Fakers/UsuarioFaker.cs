using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using TechChallenge.GameStore.Application.Usuarios.Cadastrar;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Application.Usuarios.Fakers;

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

    public static List<Usuario> ConverterParaUsuarios()
    {
        return new List<Usuario>
        {
            new AutoFaker<Usuario>(),
            new AutoFaker<Usuario>(),
            new AutoFaker<Usuario>(),
        };
    }
    
    public static List<Usuario> ListaNaoOrdenadaPorId()
    {
        var lista = new AutoFaker<Usuario>()
            .Generate(5);
        return lista.OrderByDescending(u => u.Id).ToList();
    }
}