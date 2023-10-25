using AutoMapper;
using CarsManagement.Server.Application;
using CarsManagement.Server.Domain.Entities;
using CarsManagement.Server.Presentation.AuthChainOfResponsibility.Login;
using CarsManagement.Server.Presentation.AuthChainOfResponsibility.Registration;
using CarsManagement.Shared.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarsManagement.Server.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public AuthController(ILogger<AuthController> logger, IRepository<ManagerModel> repository, IMapper mapper,
        IOptions<ApiSettings> options)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
        Settings = options;
    }

    private ILogger<AuthController> Logger { get; }

    private IRepository<ManagerModel> Repository { get; }

    private IMapper Mapper { get; }

    private IOptions<ApiSettings> Settings { get; set; }

    /// <summary>
    ///     Logs in a user.
    /// </summary>
    /// <param name="request">The login request.</param>
    /// <returns>Returns a status indicating the result of the login attempt.</returns>
    [HttpPost("login")]
    [ApiExplorerSettings(IgnoreApi = true)]  // Hide this endpoint from Swagger
    [SwaggerOperation(Summary = "Logs in a user.",
        Description = "Logs in a user and returns a status indicating the result of the login attempt.")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            Logger.LogInformation("Login attempt for user {Username}", request.Username);

            var context = new AuthContext
            {
                Logger = Logger,
                Repository = Repository,
                HttpContext = HttpContext,
                LoginRequest = request
            };
            var handler = new UserValidationHandler();
            return await handler.HandleAsync(context);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error occurred while logging in user {request.Username}. Exception: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("SwaggerLogin")]
    [SwaggerOperation(Summary = "Logs in a user for Swagger.",
        Description = "Logs in a user for Swagger and returns a JWT token.")]
    public async Task<IActionResult> LoginForSwagger([FromBody] LoginRequest request)
    {
        try
        {
            Logger.LogInformation("Login attempt for Swagger user {Username}", request.Username);

            var context = new AuthContext
            {
                Logger = Logger,
                Repository = Repository,
                HttpContext = HttpContext,
                LoginRequest = request
            };
            var handler = new UserValidationHandler();
            var result = await handler.HandleAsync(context);

            if (result is OkObjectResult okResult)
            {
                var token = GenerateJwtToken(request.Username);
                return Ok(new { token });
            }

            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error occurred while logging in Swagger user {request.Username}. Exception: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    ///     Registers a new user.
    /// </summary>
    /// <param name="request">The registration request.</param>
    /// <returns>Returns a status indicating the result of the registration attempt.</returns>
    [HttpPost("register")]
    [SwaggerOperation(Summary = "Registers a new user.",
        Description = "Registers a new user and returns a status indicating the result of the registration attempt.")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        try
        {
            Logger.LogInformation($"Registration attempt for user {request.Username}");

            var context = new AuthContext
            {
                Logger = Logger,
                Repository = Repository,
                HttpContext = HttpContext,
                RegistrationRequest = request
            };
            var handler = new NewUserValidationHandler();
            return await handler.HandleAsync(context);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"Error occurred while registering user {request.Username}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    ///     Logout a new user.
    /// </summary>
    /// <param name="request">The Logout request.</param>
    /// <returns>Returns a status indicating the result of the logout attempt otherwise return server error code.</returns>
    [HttpPost("logout")]
    [ApiExplorerSettings(IgnoreApi = true)]  // Hide this endpoint from Swagger
    [SwaggerOperation(Summary = "Registers a new user.",
        Description = "Registers a new user and returns a status indicating the result of the registration attempt.")]
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

    private string GenerateJwtToken(string username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Value.JwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            // Add other claims as needed
        };

        var token = new JwtSecurityToken(
            issuer: Settings.Value.JwtIssuer,
            audience: Settings.Value.JwtAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30), // or whatever expiration time you want
            signingCredentials: credentials
        );

        
        var handler = new JwtSecurityTokenHandler().WriteToken(token);
        return handler;
    }
}