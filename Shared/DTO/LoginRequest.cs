using System.Diagnostics;

namespace CarsManagement.Shared.DTO;

[DebuggerDisplay("{ToString(),nq}")]
public sealed record LoginRequest(string Username, string Password)
{
    public string Username { get; set; } = Username;

    public string Password { get; set; } = Password;

    public override string ToString()
    {
        return $"Username: {Username}, Password: {Password}";
    }
}