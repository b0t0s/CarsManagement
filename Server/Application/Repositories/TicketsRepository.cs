using AutoMapper;
using CarsManagement.Server.Domain;
using CarsManagement.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarsManagement.Server.Application.Repositories;

public class TicketsRepository : IRepository<TicketModel>
{
    private readonly ApplicationDbContext _context;

    public TicketsRepository(ApplicationDbContext context, ILogger<TicketsRepository> logger, IMapper mapper)
    {
        _context = context;
        Mapper = mapper;
        Logger = logger;

        _context.Database.EnsureCreated();
    }

    private IMapper Mapper { get; }

    private ILogger<TicketsRepository> Logger { get; }

    public TicketModel GetItem(int id)
    {
        var entity = _context.ParkingTickets.Find(id);
        return entity;
    }

    public List<TicketModel> GetItems()
    {
        var entities = _context.ParkingTickets.AsNoTracking().Include(z => z.Car).ToList();

        return entities;
    }

    public void Add(TicketModel item)
    {
        //var entity = Mapper.Map<TicketModel>(item);

        _context.ParkingTickets.Add(item);
        _context.SaveChanges();
    }

    public void Update(TicketModel item)
    {
        //var entity = Mapper.Map<TicketModel>(item);

        _context.ParkingTickets.Update(item);
        _context.SaveChanges();
    }

    public void AddOrUpdate(TicketModel item)
    {
        //var entity = Mapper.Map<TicketModel>(item);

        var existingManager = _context.ParkingTickets
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == item.Id);

        if (existingManager != null)
            // Update the entity if it exists
            _context.Entry(existingManager).CurrentValues.SetValues(item);
        else
            // Add the entity if it doesn't exist
            _context.ParkingTickets.Add(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var car = _context.ParkingTickets.Find(id);

        if (car != null)
        {
            _context.ParkingTickets.Remove(car);
            _context.SaveChanges();
        }
    }
}