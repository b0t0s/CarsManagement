namespace CarsManagement.Shared.DTO;

public sealed record LoginRequest(string Username, string Password)
{
    public string Username { get; set; } = Username;

    public string Password { get; set; } = Password;
}