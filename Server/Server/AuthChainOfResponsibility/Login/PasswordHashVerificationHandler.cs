using CarsManagement.Server.Application;
using Microsoft.AspNetCore.Mvc;

namespace CarsManagement.Server.Presentation.AuthChainOfResponsibility.Login;

public class PasswordHashVerificationHandler : IAuthApprover
{
    public async Task<IActionResult> HandleAsync(AuthContext context)
    {
        var managerData = context.Repository.GetItems()
            .FirstOrDefault(x => x.AccountName == context.LoginRequest.Username);
        if (!BCrypt.Net.BCrypt.Verify(context.LoginRequest.Password, managerData.PasswordHash))
        {
            context.Logger.LogWarning($"Password mismatch for user {context.LoginRequest.Username}");

            return new ObjectResult("Password Incorrect")
            {
                StatusCode = 401
            };
        }

        context.Next = new LoginSuccessHandler();
        return await context.Next.HandleAsync(context);
    }
}