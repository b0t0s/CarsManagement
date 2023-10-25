using System.Security.Claims;
using CarsManagement.Server.Application;
using CarsManagement.Server.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CarsManagement.Server.Presentation.AuthChainOfResponsibility.Registration;

public class RegistrationSuccessHandler : IAuthApprover
{
    public async Task<IActionResult> HandleAsync(AuthContext context)
    {
        context.Repository.Add(new ManagerModel
        {
            AccountName = context.RegistrationRequest.Username, PasswordHash = context.RegistrationRequest.Password
        });

        var claims = new List<Claim> { new(ClaimTypes.Name, context.RegistrationRequest.Username) };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
            { AllowRefresh = true, IsPersistent = true, IssuedUtc = DateTimeOffset.Now };

        await context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authProperties);

        context.Logger.LogInformation($"User {context.RegistrationRequest.Username} registered successfully");

        return new OkObjectResult("Registration successful")
        {
            StatusCode = 200
        };
    }
}