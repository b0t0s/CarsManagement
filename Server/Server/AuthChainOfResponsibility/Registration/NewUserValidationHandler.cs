using CarsManagement.Server.Application;
using Microsoft.AspNetCore.Mvc;

namespace CarsManagement.Server.Presentation.AuthChainOfResponsibility.Registration;

public class NewUserValidationHandler : IAuthApprover
{
    public async Task<IActionResult> HandleAsync(AuthContext context)
    {
        var managerData = context.Repository.GetItems()
            .FirstOrDefault(x => x.AccountName == context.RegistrationRequest.Username);

        if (managerData != null)
        {
            context.Logger.LogWarning($"User found with username {context.LoginRequest.Username}");

            return new ObjectResult("User is already exist")
            {
                StatusCode = 401
            };
        }

        context.Next = new ClearPasswordHandler();
        return await context.Next.HandleAsync(context);
    }
}