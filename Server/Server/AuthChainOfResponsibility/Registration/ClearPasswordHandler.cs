using CarsManagement.Server.Application;
using Microsoft.AspNetCore.Mvc;

namespace CarsManagement.Server.Presentation.AuthChainOfResponsibility.Registration;

public class ClearPasswordHandler : IAuthApprover
{
    public async Task<IActionResult> HandleAsync(AuthContext context)
    {
        context.RegistrationRequest.Password = BCrypt.Net.BCrypt.HashPassword(context.RegistrationRequest.Password);

        context.Next = new RegistrationSuccessHandler();
        return await context.Next.HandleAsync(context);
    }
}