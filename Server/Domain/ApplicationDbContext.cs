using System.Diagnostics;
using CarsManagement.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsManagement.Server.Domain;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ManagerModel> Managers { get; set; }

    public DbSet<LotModel> ParkingLots { get; set; }

    public DbSet<SpotModel> ParkingSpots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Manager to ParkingLot relationship (one-to-many)
        modelBuilder.Entity<ManagerModel>()
            .HasMany(m => m.ManagedParkingLots)
            .WithOne()
            .HasForeignKey(pl => pl.ManagerId);

        // ParkingLot to ParkingSpot relationship (one-to-many)
        modelBuilder.Entity<LotModel>()
            .HasMany(pl => pl.ParkingSpots)
            .WithOne()
            .HasForeignKey(ps => ps.LotId);

        modelBuilder.Entity<SpotModel>()
            .OwnsOne(s => s.ParkedCar);

        modelBuilder.Entity<SpotModel>()
            .OwnsOne(s => s.Ticket);

        Debug.WriteLine("Seeding DB...");

        modelBuilder.Seed();

        Debug.WriteLine("Seeded!");
    }
}