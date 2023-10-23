using AutoMapper;
using CarsManagement.Server.Application;
using CarsManagement.Server.Domain.Entities;
using CarsManagement.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace CarsManagement.Server.Presentation.Controllers;

[Authorize]
[ApiController]
[Route("[Controller]")]
public class ManagersController : ControllerBase
{
    private ILogger<ManagersController> Logger { get; set; }

    private IRepository<ManagerModel> Repository { get; set; }

    private IMapper Mapper { get; set; }

    private IOptions<ApiSettings> Settings { get; set; }

    public ManagersController(ILogger<ManagersController> logger, IRepository<ManagerModel> repository, IMapper mapper, IOptions<ApiSettings> options)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
        Settings = options;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Fetches all managers",
        Description = "Retrieves a list of all managers"
    )]
    public async Task<IActionResult> Get()
    {
        try
        {
            var items = Repository.GetItems();

            var managers = Mapper.Map<List<ManagerDTO>>(items);

            return Ok(managers);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpGet("/Managers/Manager/Id/{id:int}")]
    [SwaggerOperation(
        Summary = "Fetches a manager by ID",
        Description = "Retrieves a single manager its ID"
    )]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var item = Repository.GetItem(id);

            var manager = Mapper.Map<ManagerDTO>(item);

            return Ok(manager);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new manager",
        Description = "Adds a new manager"
    )]
    public async Task<IActionResult> Create([FromBody] ManagerDTO managerDto)
    {
        try
        {
            var managerModel = Mapper.Map<ManagerModel>(managerDto);
            Repository.Add(managerModel);

            return CreatedAtAction(nameof(Get), new { id = managerModel.Id }, managerDto);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");
            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Updates an existing manager",
        Description = "Modifies an existing manager"
    )]
    public async Task<IActionResult> Update(int id, [FromBody] ManagerDTO managerDto)
    {
        try
        {
            var existingManager = Repository.GetItem(id);
            if (existingManager == null)
            {
                return NotFound();
            }

            Mapper.Map(managerDto, existingManager);
            Repository.Update(existingManager);

            return NoContent();
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");
            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(
        Summary = "Deletes a manager by ID",
        Description = "Removes a manager by its ID"
    )]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Repository.Delete(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");
            return StatusCode(500, $"Exception: {e.Message}");
        }
    }
}