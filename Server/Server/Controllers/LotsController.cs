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
public class LotsController : ControllerBase
{
    private ILogger<LotsController> Logger { get; set; }

    private IRepository<LotModel> Repository { get; set; }

    private IMapper Mapper { get; set; }

    private IOptions<ApiSettings> Settings { get; set; }

    public LotsController(ILogger<LotsController> logger, IRepository<LotModel> repository, IMapper mapper, IOptions<ApiSettings> options)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
        Settings = options;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Fetches all parking lots",
        Description = "Retrieves a list of all parking lots"
    )]
    public async Task<IActionResult> Get()
    {
        try
        {
            var items = Repository.GetItems();

            var lots = Mapper.Map<List<ParkingLotDTO>>(items);

            return Ok(lots);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpGet("/Lots/Lot/Id/{id:int}")]
    [SwaggerOperation(
        Summary = "Fetches a parking lot by ID",
        Description = "Retrieves a single parking lot by its ID"
    )]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var item = Repository.GetItem(id);

            var lot = Mapper.Map<ParkingLotDTO>(item);

            return Ok(lot);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new parking lot",
        Description = "Adds a new parking lot"
    )]
    public async Task<IActionResult> Create([FromBody] ParkingLotDTO parkingLotDto)
    {
        try
        {
            var lotModel = Mapper.Map<LotModel>(parkingLotDto);
            Repository.Add(lotModel);

            return CreatedAtAction(nameof(Get), new { id = lotModel.Id }, parkingLotDto);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");
            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Updates an existing parking lot",
        Description = "Modifies an existing parking lot"
    )]
    public async Task<IActionResult> Update(int id, [FromBody] ParkingLotDTO parkingLotDto)
    {
        try
        {
            var existingLot = Repository.GetItem(id);
            if (existingLot == null)
            {
                return NotFound();
            }

            Mapper.Map(parkingLotDto, existingLot);
            Repository.Update(existingLot);

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
        Summary = "Deletes a parking lot by ID",
        Description = "Removes a parking lot by its ID"
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