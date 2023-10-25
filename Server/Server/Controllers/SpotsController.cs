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
public class SpotsController : ControllerBase
{
    public SpotsController(ILogger<SpotsController> logger, IRepository<SpotModel> repository, IMapper mapper,
        IOptions<ApiSettings> options)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
        Settings = options;
    }

    private ILogger<SpotsController> Logger { get; }

    private IRepository<SpotModel> Repository { get; }

    private IMapper Mapper { get; }

    private IOptions<ApiSettings> Settings { get; set; }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Fetches all parking spots",
        Description = "Retrieves a list of all parking spots"
    )]
    public async Task<IActionResult> Get()
    {
        try
        {
            var items = Repository.GetItems();

            var spots = Mapper.Map<List<ParkingSpotDTO>>(items);

            return Ok(spots);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpGet("/Spots/Spot/Id/{id:int}")]
    [SwaggerOperation(
        Summary = "Fetches a parking spot by ID",
        Description = "Retrieves a single parking spot by its ID"
    )]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var item = Repository.GetItem(id);

            var spot = Mapper.Map<ParkingLotDTO>(item);

            return Ok(spot);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new parking spot",
        Description = "Adds a new parking spot"
    )]
    public async Task<IActionResult> Create([FromBody] ParkingSpotDTO spotDto)
    {
        try
        {
            var spotModel = Mapper.Map<SpotModel>(spotDto);
            Repository.Add(spotModel);

            return CreatedAtAction(nameof(Get), new { id = spotModel.Id }, spotDto);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");
            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Updates an existing parking spot",
        Description = "Modifies an existing parking spot"
    )]
    public async Task<IActionResult> Update(int id, [FromBody] ParkingSpotDTO spotDto)
    {
        try
        {
            var existingSpot = Repository.GetItem(id);
            if (existingSpot == null) return NotFound();

            Mapper.Map(spotDto, existingSpot);
            Repository.Update(existingSpot);

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
        Summary = "Deletes a parking spot by ID",
        Description = "Removes a parking spot by its ID"
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