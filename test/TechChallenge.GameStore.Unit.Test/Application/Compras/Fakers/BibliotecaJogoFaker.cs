using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos.Fakers;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras.Fakers;

public static class BibliotecaJogoFaker
{
    public static BibliotecaJogo Criar(int usuarioId, int jogoId)
    {
        var jogo = JogoFaker.ComNome($"Jogo {jogoId}");
        jogo.GetType().GetProperty("Id")?.SetValue(jogo, jogoId);

        var usuario = CriarUsuarioFake(usuarioId);

        return new BibliotecaJogo
        {
            UsuarioId = usuarioId,
            JogoId = jogoId,
            Jogo = jogo,
            Usuario = usuario
        };
    }

    public static List<BibliotecaJogo> ListaParaUsuario(int usuarioId, int quantidade = 3)
    {
        return Enumerable.Range(1, quantidade)
            .Select(i => Criar(usuarioId, i))
            .ToList();
    }

    private static Usuario CriarUsuarioFake(int id)
    {
        var ctor = typeof(Usuario).GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            new[] { typeof(string), typeof(string), typeof(string) },
            null
        );

        var usuario = (Usuario)ctor!.Invoke(new object[] { $"Usuário {id}", $"usuario{id}@teste.com", "SenhaSegura123" });

        typeof(Usuario).GetProperty("Id")?.SetValue(usuario, id);

        return usuario;
    }
}
