using CarsManagement.Server.Domain.Entities;
using CarsManagement.Server.Presentation.AuthChainOfResponsibility;
using CarsManagement.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CarsManagement.Server.Application;

public class AuthContext
{
    public ILogger Logger { get; set; }
    public IRepository<ManagerModel> Repository { get; set; }
    public HttpContext HttpContext { get; set; }

    public LoginRequest LoginRequest { get; set; }
    public RegistrationRequest RegistrationRequest { get; set; }

    public IAuthApprover Next { get; set; }
}