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

    public DbSet<CarModel> Cars { get; set; }

    public DbSet<TicketModel> ParkingTickets { get; set; }

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

        // ParkingSpot to Car relationship (one-to-one)
        modelBuilder.Entity<SpotModel>()
            .HasOne(ps => ps.ParkedCar)
            .WithOne()
            .HasForeignKey<CarModel>(c => c.Id);

        // Ensure SpotId is unique across all ParkingSpotModels
        modelBuilder.Entity<SpotModel>()
            .HasIndex(ps => ps.Id)
            .IsUnique();

        // Car to Ticket relationship (one-to-one)
        modelBuilder.Entity<CarModel>()
            .HasOne(c => c.Ticket)
            .WithOne(e => e.Car)
            .HasForeignKey<TicketModel>(e => e.Id)
            .IsRequired();

        Debug.WriteLine("Seeding DB...");

        modelBuilder.Seed();

        Debug.WriteLine("Seeded!");
    }
}