using CarsManagement.Server.Application;
using Microsoft.AspNetCore.Mvc;

namespace CarsManagement.Server.Presentation.AuthChainOfResponsibility.Login;

public class UserValidationHandler : IAuthApprover
{
    public async Task<IActionResult> HandleAsync(AuthContext context)
    {
        var managerData = context.Repository.GetItems()
            .FirstOrDefault(x => x.AccountName == context.LoginRequest.Username);
        if (managerData == null)
        {
            context.Logger.LogWarning("No user found with username {Username}", context.LoginRequest.Username);
            return new ObjectResult("Username Incorrect or User is not exist")
            {
                StatusCode = 401
            };
        }

        context.Next = new PasswordHashVerificationHandler();
        return await context.Next.HandleAsync(context);
    }
}