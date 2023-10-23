using CarsManagement.Server.Domain;
using CarsManagement.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarsManagement.Server.Application.Repositories;

public class CarsRepository : IRepository<CarModel>
{
    private readonly ApplicationDbContext _context;

    private ILogger<CarsRepository> Logger { get; }

    public CarsRepository(ApplicationDbContext context, ILogger<CarsRepository> logger)
    {
        _context = context;
        Logger = logger;

        _context.Database.EnsureCreated();
    }

    public CarModel GetItem(int id)
    {
        var entity = _context.Cars.Find(id);

        return entity; 
    }

    public List<CarModel> GetItems()
    {
        var entities = _context.Cars.Include(c => c.Ticket).ToList();

        return entities; 
    }

    public void Add(CarModel item)
    {
        _context.Cars.Add(item);

        _context.SaveChanges();
    }

    public void Update(CarModel item)
    {
        _context.Cars.Update(item);

        _context.SaveChanges();
    }

    public void AddOrUpdate(CarModel item)
    {
        var existingManager = _context.Cars
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == item.Id);

        if (existingManager != null)
        {
            // Update the entity if it exists
            _context.Entry(existingManager).CurrentValues.SetValues(item);
        }
        else
        {
            // Add the entity if it doesn't exist
            _context.Cars.Add(item);
        }

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var car = _context.Cars.Find(id);

        if (car != null)
        {
            _context.Cars.Remove(car);

            _context.SaveChanges();
        }
    }
}