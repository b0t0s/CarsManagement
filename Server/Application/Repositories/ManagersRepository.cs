using AutoMapper;
using CarsManagement.Server.Domain;
using CarsManagement.Server.Domain.Entities;
using CarsManagement.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarsManagement.Server.Application.Repositories;

public class ManagersRepository : IRepository<ManagerModel>
{
    private readonly ApplicationDbContext _context;

    public ManagersRepository(ApplicationDbContext context, ILogger<ManagersRepository> logger, IMapper mapper)
    {
        _context = context;
        Mapper = mapper;
        Logger = logger;

        _context.Database.EnsureCreated();
    }

    private IMapper Mapper { get; }

    private ILogger<ManagersRepository> Logger { get; }

    public ManagerModel GetItem(int id)
    {
        var entity = _context.Managers.Find(id);
        if (entity == null)
        {
            Logger.LogWarning("No manager found with id {Id}", id);

            return null; // or throw an exception if appropriate
        }


        return entity;
    }

    public List<ManagerModel> GetItems()
    {
        var entities = _context.Managers.AsNoTracking().Include(x => x.ManagedParkingLots)
            .ThenInclude(y => y.ParkingSpots).ThenInclude(z => z.ParkedCar).ThenInclude(v => v.Ticket).ToList();

        return entities;
        Mapper.Map<List<ManagerDTO>>(entities);
    }

    public void Add(ManagerModel item)
    {
        //var entity = Mapper.Map<ManagerModel>(item);

        _context.Managers.Add(item);
        _context.SaveChanges();
    }

    public void Update(ManagerModel item)
    {
        //var entity = Mapper.Map<ManagerModel>(item);

        _context.Managers.Update(item);
        _context.SaveChanges();
    }

    public void AddOrUpdate(ManagerModel item)
    {
        //var entity = Mapper.Map<ManagerModel>(item);

        var existingManager = _context.Managers
            .AsNoTracking()
            .FirstOrDefault(p => p.AccountName == item.AccountName);

        if (existingManager != null)
            // Update the entity if it exists
            _context.Entry(existingManager).CurrentValues.SetValues(item);
        else
            // Add the entity if it doesn't exist
            _context.Managers.Add(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var manager = _context.Managers.Find(id);

        if (manager != null)
        {
            _context.Managers.Remove(manager);
            _context.SaveChanges();
        }
    }
}