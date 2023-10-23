using System.Security.Claims;
using AutoMapper;
using CarsManagement.Server.Application;
using CarsManagement.Server.Domain.Entities;
using CarsManagement.Shared.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using static BCrypt.Net.BCrypt;

namespace CarsManagement.Server.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private ILogger<AuthController> Logger { get; set; }

    private IRepository<ManagerModel> Repository { get; set; }

    private IMapper Mapper { get; }

    private IOptions<ApiSettings> Settings { get; set; }

    public AuthController(ILogger<AuthController> logger, IRepository<ManagerModel> repository, IMapper mapper, IOptions<ApiSettings> options)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
        Settings = options;
    }

    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="request">The login request.</param>
    /// <returns>Returns a status indicating the result of the login attempt.</returns>
    [HttpPost("login")]
    [SwaggerOperation(Summary = "Logs in a user.", Description = "Logs in a user and returns a status indicating the result of the login attempt.")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            Logger.LogInformation("Login attempt for user {Username}", request.Username);

            var managerData = Repository.GetItems().FirstOrDefault(x => x.AccountName == request.Username);

            if (managerData != null)
            {
                if (Verify(request.Password, managerData.PasswordHash))
                {
                    Logger.LogInformation("Password matched for user {Username}", request.Username);

                    var claims = new List<Claim> { new(ClaimTypes.Name, request.Username) };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties { AllowRefresh = true, IsPersistent = true, IssuedUtc = DateTimeOffset.Now };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return new ObjectResult("Login successful")
                    {
                        StatusCode = 200
                    };
                }

                Logger.LogWarning("Password mismatch for user {Username}", request.Username);

                return new ObjectResult("Password Incorrect")
                {
                    StatusCode = 401
                };
            }

            Logger.LogWarning("No user found with username {Username}", request.Username);

            return new ObjectResult("Username Incorrect or User is not exist")
            {
                StatusCode = 401
            };
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error occurred while logging in user {Username}", request.Username);

            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="request">The registration request.</param>
    /// <returns>Returns a status indicating the result of the registration attempt.</returns>
    [HttpPost("register")]
    [SwaggerOperation(Summary = "Registers a new user.", Description = "Registers a new user and returns a status indicating the result of the registration attempt.")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        try
        {
            Logger.LogInformation($"Registration attempt for user {request.Username}");

            var managerData = Repository.GetItems().FirstOrDefault(x => x.AccountName == request.Username);

            if (managerData == null)
            {
                var hashedPassword = HashPassword(request.Password);

                Repository.Add(new ManagerModel() { AccountName = request.Username, PasswordHash = hashedPassword });

                Logger.LogInformation($"User {request.Username} registered successfully");

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.Username) };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties { AllowRefresh = true, IsPersistent = true, IssuedUtc = DateTimeOffset.Now };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return Ok();
            }

            Logger.LogWarning($"User with username {request.Username} already exists");

            return new ObjectResult("User already exist")
            {
                StatusCode = 401
            };
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"Error occurred while registering user {request.Username}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Logout a new user.
    /// </summary>
    /// <param name="request">The Logout request.</param>
    /// <returns>Returns a status indicating the result of the logout attempt otherwise return server error code.</returns>
    [HttpPost("logout")]
    [SwaggerOperation(Summary = "Registers a new user.", Description = "Registers a new user and returns a status indicating the result of the registration attempt.")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            Logger.LogInformation("Logout initiated");

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            Logger.LogInformation("Logout completed");

            return Ok();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error occurred while logging out user");

            return StatusCode(500, "Internal server error");
        }
    }
}
