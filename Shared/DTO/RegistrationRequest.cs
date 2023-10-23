namespace CarsManagement.Shared.DTO;

public sealed record RegistrationRequest(string Username, string Email, string Password)
{
    public string Username { get; set; } = Username;

    public string Email { get; set; } = Email;

    public string Password { get; set; } = Password;

    public bool ComparePassword(string passwordToCompare)
    {
        return Password.Equals(passwordToCompare);
    }
}