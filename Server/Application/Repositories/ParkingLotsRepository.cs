﻿using AutoMapper;
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
        var entities = _context.ParkingLots.AsNoTracking()
            .Include(y => y.ParkingSpots).ThenInclude(z => z.ParkedCar)
            .Include(v => v.ParkingSpots).ThenInclude(z => z.Ticket).ToList();

        return entities;
    }

    public void Add(LotModel item)
    {
        _context.ParkingLots.Add(item);
        _context.SaveChanges();
    }

    public void Update(LotModel item)
    {
        var entity = Mapper.Map<LotModel>(item);

        _context.ParkingLots.Update(item);
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