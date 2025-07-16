namespace TechChallenge.GameStore.Domain._Shared;

public static class SenhaExtension
{
    public static string GerarHash(string senha)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(senha));
    }

    public static Result<bool> ValidarSenha(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
            return Result.Failure<bool>("Senha é obrigatória.");

        if (senha.Length > 8)
            return Result.Failure<bool>("Senha deve conter no máximo 8 caracteres.");

        if (!System.Text.RegularExpressions.Regex.IsMatch(senha, @"[A-Za-z]"))
            return Result.Failure<bool>("Senha deve conter pelo menos uma letra.");

        if (!System.Text.RegularExpressions.Regex.IsMatch(senha, @"[0-9]"))
            return Result.Failure<bool>("Senha deve conter pelo menos um número.");

        if (!System.Text.RegularExpressions.Regex.IsMatch(senha, @"[^A-Za-z0-9]"))
            return Result.Failure<bool>("Senha deve conter pelo menos um caractere especial.");

        return Result.Success(true);
    }
}