using System.Collections.Generic;
using AutoBogus;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Fakers;

public static class UsuarioFaker
{
    public static List<Usuario> ListaValida(int quantidade)
        => new AutoFaker<Usuario>().Generate(quantidade);
}