using AutoMapper;
using CarsManagement.Server.Domain;
using CarsManagement.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarsManagement.Server.Application.Repositories;

public class ParkingSpotsRepository : IRepository<SpotModel>
{
    private readonly ApplicationDbContext _context;

    public ParkingSpotsRepository(ApplicationDbContext context, ILogger<ParkingSpotsRepository> logger, IMapper mapper)
    {
        _context = context;
        Mapper = mapper;
        Logger = logger;

        _context.Database.EnsureCreated();
    }

    private IMapper Mapper { get; }

    private ILogger<ParkingSpotsRepository> Logger { get; }

    public SpotModel GetItem(int id)
    {
        var entity = _context.ParkingSpots.Find(id);

        return entity;
    }

    public List<SpotModel> GetItems()
    {
        var entities = _context.ParkingSpots.AsNoTracking().Include(z => z.ParkedCar).ThenInclude(v => v.Ticket)
            .ToList();

        return entities;
    }

    public void Add(SpotModel item)
    {
        //var entity = Mapper.Map<SpotModel>(item);

        _context.ParkingSpots.Add(item);
        _context.SaveChanges();
    }

    public void Update(SpotModel item)
    {
        //var entity = Mapper.Map<SpotModel>(item);

        _context.ParkingSpots.Update(item);
        _context.SaveChanges();
    }

    public void AddOrUpdate(SpotModel item)
    {
        //var entity = Mapper.Map<SpotModel>(item);

        var existingSpot = _context.ParkingSpots
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == item.Id);

        if (existingSpot != null)
            // Update the entity if it exists
            _context.Entry(existingSpot).CurrentValues.SetValues(item);
        else
            // Add the entity if it doesn't exist
            _context.ParkingSpots.Add(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var spot = _context.ParkingSpots.Find(id);

        if (spot != null)
        {
            _context.ParkingSpots.Remove(spot);
            _context.SaveChanges();
        }
    }
}