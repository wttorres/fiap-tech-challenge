using System.Text.Json;

namespace TechChallenge.GameStore.WebApi._Shared;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Trace { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}