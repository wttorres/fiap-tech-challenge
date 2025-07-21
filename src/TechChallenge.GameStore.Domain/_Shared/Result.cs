namespace TechChallenge.GameStore.Domain._Shared;

public class Result<T>
{
    public bool Sucesso { get; }
    public string Erro { get; }
    public T Valor { get; }

    protected Result(bool sucesso, string erro, T valor)
    {
        Sucesso = sucesso;
        Erro = erro;
        Valor = valor;
    }

    public static Result<T> Success(T valor) => new(true, null, valor);
    public static Result<T> Failure(string erro) => new(false, erro, default);
}

public static class Result
{
    public static Result<T> Failure<T>(string erro) => Result<T>.Failure(erro);
    public static Result<T> Success<T>(T valor) => Result<T>.Success(valor);
}