using System.Diagnostics;

namespace CarsManagement.Shared.DTO;

[DebuggerDisplay("{ToString(),nq}")]
public sealed record RegistrationRequest(string Username, string Email, string Password)
{
    public string Username { get; set; } = Username;

    public string Email { get; set; } = Email;

    public string Password { get; set; } = Password;

    public override string ToString()
    {
        return $"Username: {Username}, Email: {Email}, Password: {Password}";
    }
}