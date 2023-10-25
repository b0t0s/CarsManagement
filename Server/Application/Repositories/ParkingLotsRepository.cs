using AutoMapper;
using CarsManagement.Server.Domain;
using CarsManagement.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarsManagement.Server.Application.Repositories;

public class ParkingLotsRepository : IRepository<LotModel>
{
    private readonly ApplicationDbContext _context;

    public ParkingLotsRepository(ApplicationDbContext context, ILogger<ParkingLotsRepository> logger, IMapper mapper)
    {
        _context = context;
        Mapper = mapper;
        Logger = logger;

        _context.Database.EnsureCreated();
    }

    private IMapper Mapper { get; }

    private ILogger<ParkingLotsRepository> Logger { get; }

    public LotModel GetItem(int id)
    {
        var entity = _context.ParkingLots.Find(id);

        return entity;
    }

    public List<LotModel> GetItems()
    {
        var entities = _context.ParkingLots.AsNoTracking().Include(y => y.ParkingSpots).ThenInclude(z => z.ParkedCar)
            .ThenInclude(v => v.Ticket).ToList();

        return entities;
    }

    public void Add(LotModel item)
    {
        //var entity = Mapper.Map<LotModel>(item);

        _context.ParkingLots.Add(item);
        _context.SaveChanges();
    }

    public void Update(LotModel item)
    {
        var entity = Mapper.Map<LotModel>(item);

        _context.ParkingLots.Update(item);
        _context.SaveChanges();
    }

    public void AddOrUpdate(LotModel item)
    {
        //var entity = Mapper.Map<LotModel>(item);

        var parkingLot = _context.ParkingLots
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == item.Id);

        if (parkingLot != null)
            // Update the entity if it exists
            _context.Entry(parkingLot).CurrentValues.SetValues(item);
        else
            // Add the entity if it doesn't exist
            _context.ParkingLots.Add(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var lot = _context.ParkingLots.Find(id);
        if (lot != null)
        {
            _context.ParkingLots.Remove(lot);
            _context.SaveChanges();
        }
    }
}