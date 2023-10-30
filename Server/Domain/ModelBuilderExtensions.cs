using CarsManagement.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsManagement.Server.Domain;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var managers = new List<ManagerModel>
        {
            new()
            {
                Id = 1, AccountName = "Mick Jagger",
                PasswordHash = "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7."
            },
            new()
            {
                Id = 2, AccountName = "Jimi Hendrix",
                PasswordHash = "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7."
            }
        };

        // Seeding Managers
        modelBuilder.Entity<ManagerModel>().HasData(managers);

        // Debug.WriteLine statements
        Console.WriteLine($"Total Managers: {managers.Count}. First: {managers.First().AccountName} - {managers.First().PasswordHash}");

        var lots = new List<LotModel>
        {
            new() { Id = 1, ManagerId = 1, LotName = "Garage California", LotLocation = "Rock" },
            new() { Id = 2, ManagerId = 2, LotName = "Garage of the Rising Sun", LotLocation = "Rock" }
        };

        // Seeding Parking Lots managed by the Managers
        modelBuilder.Entity<LotModel>().HasData(lots);

        var spots = new List<SpotModel>
        {
            new() { Id = 1, LotId = 1, IsOccupied = false },
            new() { Id = 2, LotId = 1, IsOccupied = false },
            new() { Id = 3, LotId = 1, IsOccupied = false },
            new() { Id = 4, LotId = 1, IsOccupied = false },
            new() { Id = 5, LotId = 1, IsOccupied = false },
            new() { Id = 6, LotId = 1, IsOccupied = false },
            new() { Id = 7, LotId = 1, IsOccupied = false },
            new() { Id = 8, LotId = 1, IsOccupied = false },
            new() { Id = 9, LotId = 1, IsOccupied = false },
            new() { Id = 10, LotId = 1, IsOccupied = false },
            new() { Id = 11, LotId = 1, IsOccupied = false },
            new() { Id = 12, LotId = 1, IsOccupied = false },


            new() { Id = 13, LotId = 2, IsOccupied = false },
            new() { Id = 14, LotId = 2, IsOccupied = false },
            new() { Id = 15, LotId = 2, IsOccupied = false },
            new() { Id = 16, LotId = 2, IsOccupied = false },
            new() { Id = 17, LotId = 2, IsOccupied = false },
            new() { Id = 18, LotId = 2, IsOccupied = false },
            new() { Id = 19, LotId = 2, IsOccupied = false },
            new() { Id = 20, LotId = 2, IsOccupied = false },
            new() { Id = 21, LotId = 2, IsOccupied = false },
            new() { Id = 22, LotId = 2, IsOccupied = false },
            new() { Id = 23, LotId = 2, IsOccupied = false },
            new() { Id = 24, LotId = 2, IsOccupied = false }
        };

        // Seeding Parking Spots within a Parking Lot
        modelBuilder.Entity<SpotModel>().HasData(spots);

        Console.WriteLine($"Total Parking Lots: {lots.Count}");
        Console.WriteLine($"Total Occupied Spots: {spots.Count(s => s.IsOccupied)}");
        Console.WriteLine($"Total Not Occupied Spots: {spots.Count(s => !s.IsOccupied)}");
        Console.WriteLine($"Total Inclusive Occupied Spots: {spots.Count(s => s.IsOccupied)}");
        Console.WriteLine($"Total Inclusive Not Occupied Spots: {spots.Count(s => !s.IsOccupied)}");
    }
}