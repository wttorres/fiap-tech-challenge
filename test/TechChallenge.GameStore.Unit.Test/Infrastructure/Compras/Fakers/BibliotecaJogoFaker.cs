using System.Collections.Generic;
using System.Linq;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos.Fakers;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Compras.Fakers;

public static class BibliotecaJogoFaker
{
    public static BibliotecaJogo Valido(int usuarioId, int jogoId)
    {
        var usuario = Usuario.Criar($"Usuario {usuarioId}", $"usuario{usuarioId}@email.com", "Senha123!").Valor!;
        var jogo = JogoFaker.ComNome($"Jogo {jogoId}");

        // Força os IDs corretos para garantir que o EF funcione como esperado nas queries
        usuario.GetType().GetProperty("Id")?.SetValue(usuario, usuarioId);
        jogo.GetType().GetProperty("Id")?.SetValue(jogo, jogoId);

        return new BibliotecaJogo
        {
            UsuarioId = usuarioId,
            Usuario = usuario,
            JogoId = jogoId,
            Jogo = jogo
        };
    }

    public static List<BibliotecaJogo> ListaParaUsuario(int usuarioId, int quantidade = 3)
    {
        return Enumerable.Range(1, quantidade)
            .Select(i => Valido(usuarioId, i))
            .ToList();
    }
}
