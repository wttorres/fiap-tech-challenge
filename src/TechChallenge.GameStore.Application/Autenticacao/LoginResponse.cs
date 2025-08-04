namespace TechChallenge.GameStore.Application.Autenticacao;

public class LoginResponse
{
    public int UsuarioId { get; set; }
    public string Email { get; set; } = default!;
    public string Perfil { get; set; } = default!;
    public string Token { get; set; } = default!;
}