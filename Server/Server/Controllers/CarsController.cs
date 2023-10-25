using AutoMapper;
using CarsManagement.Server.Application;
using CarsManagement.Server.Domain.Entities;
using CarsManagement.Shared.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace CarsManagement.Server.Presentation.Controllers;

[Authorize]
[ApiController]
[Route("[Controller]")]
public class CarsController : ControllerBase
{
    public CarsController(ILogger<CarsController> logger, IRepository<CarModel> repository, IMapper mapper, IOptions<ApiSettings> options)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
        Settings = options;
    }

    private ILogger<CarsController> Logger { get; }

    private IRepository<CarModel> Repository { get; }

    private IMapper Mapper { get; }

    private IOptions<ApiSettings> Settings { get; set; }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Fetches all cars",
        Description = "Retrieves a list of all cars from the repository"
    )]
    public async Task<IActionResult> Get()
    {
        try
        {
            var items = Repository.GetItems();

            var cars = Mapper.Map<List<CarDTO>>(items);

            return Ok(cars);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpGet("/Cars/Car/Id/{id:int}")]
    [SwaggerOperation(
        Summary = "Fetches a car by ID",
        Description = "Retrieves a single car from the repository by its ID"
    )]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var item = Repository.GetItem(id);

            var car = Mapper.Map<CarDTO>(item);

            return Ok(car);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new car",
        Description = "Adds a new car to the repository"
    )]
    public async Task<IActionResult> Create([FromBody] CarDTO carDto)
    {
        try
        {
            var carModel = Mapper.Map<CarModel>(carDto);
            Repository.Add(carModel);

            return CreatedAtAction(nameof(Get), new { id = carModel.Id }, carDto);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");
            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Updates an existing car",
        Description = "Modifies an existing car in the repository"
    )]
    public async Task<IActionResult> Update(int id, [FromBody] CarDTO carDto)
    {
        try
        {
            var existingCar = Repository.GetItem(id);
            if (existingCar == null) return NotFound();

            Mapper.Map(carDto, existingCar);
            Repository.Update(existingCar);

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
        Summary = "Deletes a car by ID",
        Description = "Removes a car from the repository by its ID"
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