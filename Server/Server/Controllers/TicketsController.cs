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
public class TicketsController : ControllerBase
{
    private ILogger<TicketsController> Logger { get; set; }

    private IRepository<TicketModel> Repository { get; set; }

    private IMapper Mapper { get; set; }

    private IOptions<ApiSettings> Settings { get; set; }

    public TicketsController(ILogger<TicketsController> logger, IRepository<TicketModel> repository, IMapper mapper, IOptions<ApiSettings> options)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
        Settings = options;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Fetches all tickets",
        Description = "Retrieves a list of all tickets"
    )]
    public async Task<IActionResult> Get()
    {
        try
        {
            var items = Repository.GetItems();

            var tickets = Mapper.Map<List<TicketDTO>>(items);

            return Ok(tickets);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpGet("/Tickets/Ticket/Id/{id:int}")]
    [SwaggerOperation(
        Summary = "Fetches a ticket by ID",
        Description = "Retrieves a single ticket by its ID"
    )]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var item = Repository.GetItem(id);

            var ticket = Mapper.Map<List<TicketDTO>>(item);

            return Ok(ticket);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");

            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new ticket",
        Description = "Adds a new ticket"
    )]
    public async Task<IActionResult> Create([FromBody] TicketDTO ticketDto)
    {
        try
        {
            var ticketModel = Mapper.Map<TicketModel>(ticketDto);
            Repository.Add(ticketModel);

            return CreatedAtAction(nameof(Get), new { id = ticketModel.Id }, ticketDto);
        }
        catch (Exception e)
        {
            Logger.LogError($"Exception: {e.Message}");
            return StatusCode(500, $"Exception: {e.Message}");
        }
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Updates an existing ticket",
        Description = "Modifies an existing ticket"
    )]
    public async Task<IActionResult> Update(int id, [FromBody] TicketDTO ticketDto)
    {
        try
        {
            var existingTicket = Repository.GetItem(id);
            if (existingTicket == null)
            {
                return NotFound();
            }

            Mapper.Map(ticketDto, existingTicket);
            Repository.Update(existingTicket);

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
        Summary = "Deletes a ticket by ID",
        Description = "Removes a ticket by its ID"
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