using System.Security.Claims;
using CarsManagement.Server.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CarsManagement.Server.Presentation.AuthChainOfResponsibility.Login;

public class LoginSuccessHandler : IAuthApprover
{
    public async Task<IActionResult> HandleAsync(AuthContext context)
    {
        context.Logger.LogInformation("Password matched for user {Username}", context.LoginRequest.Username);

        var claims = new List<Claim> { new(ClaimTypes.Name, context.LoginRequest.Username) };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
            { AllowRefresh = true, IsPersistent = true, IssuedUtc = DateTimeOffset.Now };

        await context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authProperties);

        return new OkObjectResult("Login successful")
        {
            StatusCode = 200
        };
    }
}