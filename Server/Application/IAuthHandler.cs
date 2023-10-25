using CarsManagement.Server.Application;
using Microsoft.AspNetCore.Mvc;

namespace CarsManagement.Server.Presentation.AuthChainOfResponsibility;

public interface IAuthApprover
{
    Task<IActionResult> HandleAsync(AuthContext context);
}