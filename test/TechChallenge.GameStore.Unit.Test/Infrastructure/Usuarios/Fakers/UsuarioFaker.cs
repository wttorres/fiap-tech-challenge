using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Usuarios.Fakers;

public static class UsuarioFaker
{
    public static Usuario Valido()
    {
        var nome  = "João Teste";
        var email = "joao@teste.com";
        var senha = "Abc@123";

        return Usuario.Criar(nome, email, senha).Valor!;
    }
}