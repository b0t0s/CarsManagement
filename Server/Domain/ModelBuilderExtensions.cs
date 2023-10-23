﻿using CarsManagement.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsManagement.Server.Domain;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var managers = new List<ManagerModel>()
        {
            new ManagerModel { Id = 1, AccountName = "Mick Jagger", PasswordHash = "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7."},
            new ManagerModel { Id = 2, AccountName = "Jimi Hendrix", PasswordHash = "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7."},
            new ManagerModel { Id = 3, AccountName = "James Hetfield", PasswordHash = "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7" },
            new ManagerModel { Id = 4, AccountName = "Ozzy Osbourne", PasswordHash = "$2a$11$gZt2uSBLfWIDlfp.lGu8Y.9j5EpzTa9ZuG.IwMFRBakHQt0Jxym7" }
        };

        // Seeding Managers
        modelBuilder.Entity<ManagerModel>().HasData(managers);

        // Debug.WriteLine statements
        Console.WriteLine($"Total Managers: {managers.Count}. First: {managers.First().AccountName} - {managers.First().PasswordHash}");

        var lots = new List<LotModel>()
        {
            new LotModel { Id = 1, ManagerId = 1, LotName = "Garage California", LotLocation = "Rock" },
            new LotModel { Id = 2, ManagerId = 1, LotName = "Garage of the Rising Sun", LotLocation = "Rock" },
            new LotModel { Id = 3, ManagerId = 2, LotName = "Voodoo Car", LotLocation = "Rock" },
            new LotModel { Id = 4, ManagerId = 2, LotName = "Crosstown Traffic", LotLocation = "Rock" },
            new LotModel { Id = 5, ManagerId = 7, LotName = "Enter Garage", LotLocation = "Metal" },
            new LotModel { Id = 6, ManagerId = 7, LotName = "Wherever I May Roam", LotLocation = "Metal" },
            new LotModel { Id = 7, ManagerId = 8, LotName = "Crazy Car", LotLocation = "Metal" },
            new LotModel { Id = 8, ManagerId = 8, LotName = "No More Spots", LotLocation = "Metal" }
        };

        // Seeding Parking Lots managed by the Managers
        modelBuilder.Entity<LotModel>().HasData(lots);

        var spots = new List<SpotModel>()
        {
            new SpotModel { Id = 1, LotId = 1, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 2, LotId = 1, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 3, LotId = 1, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 4, LotId = 1, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 5, LotId = 1, IsOccupied = false, IsInclusive = true },

            new SpotModel { Id = 6, LotId = 2, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 7, LotId = 2, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 8, LotId = 2, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 9, LotId = 2, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 10, LotId = 2, IsOccupied = true, IsInclusive = true },

            new SpotModel { Id = 11, LotId = 3, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 12, LotId = 3, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 13, LotId = 3, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 14, LotId = 3, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 15, LotId = 3, IsOccupied = false, IsInclusive = true },

            new SpotModel { Id = 16, LotId = 4, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 17, LotId = 4, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 18, LotId = 4, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 19, LotId = 4, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 20, LotId = 4, IsOccupied = false, IsInclusive = true },

            new SpotModel { Id = 21, LotId = 5, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 22, LotId = 5, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 23, LotId = 5, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 24, LotId = 5, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 25, LotId = 5, IsOccupied = false, IsInclusive = true },

            new SpotModel { Id = 26, LotId = 6, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 27, LotId = 6, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 28, LotId = 6, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 29, LotId = 6, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 30, LotId = 6, IsOccupied = false, IsInclusive = true },

            new SpotModel { Id = 31, LotId = 7, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 32, LotId = 7, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 33, LotId = 7, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 34, LotId = 7, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 35, LotId = 7, IsOccupied = false, IsInclusive = true },

            new SpotModel { Id = 36, LotId = 8, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 37, LotId = 8, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 38, LotId = 8, IsOccupied = true, IsInclusive = false },
            new SpotModel { Id = 39, LotId = 8, IsOccupied = false, IsInclusive = false },
            new SpotModel { Id = 40, LotId = 8, IsOccupied = false, IsInclusive = true }
        };

        // Seeding Parking Spots within a Parking Lot
        modelBuilder.Entity<SpotModel>().HasData(spots);

        Console.WriteLine($"Total Parking Lots: {lots.Count}");
        Console.WriteLine($"Total Occupied Spots: {spots.Count(s => s.IsOccupied && !s.IsInclusive)}");
        Console.WriteLine($"Total Not Occupied Spots: {spots.Count(s => !s.IsOccupied && !s.IsInclusive)}");
        Console.WriteLine($"Total Inclusive Occupied Spots: {spots.Count(s => s.IsOccupied && s.IsInclusive)}");
        Console.WriteLine($"Total Inclusive Not Occupied Spots: {spots.Count(s => !s.IsOccupied && s.IsInclusive)}");

        var cars = new List<CarModel>()
        {
            new CarModel { Id = 1, Brand = "BMW", Model = "Z3" },
            new CarModel { Id = 2, Brand = "Mazda", Model = "RX8" },
            new CarModel { Id = 3, Brand = "Audi", Model = "A6" },
            new CarModel { Id = 4, Brand = "Hyundai", Model = "Elantra" },
            new CarModel { Id = 5, Brand = "Lincoln", Model = "MKX" },
            new CarModel { Id = 6, Brand = "Bugatti", Model = "Veyron" },
            new CarModel { Id = 7, Brand = "Tesla", Model = "Model S" },
            new CarModel { Id = 8, Brand = "Chevrolet", Model = "Camaro" },
            new CarModel { Id = 9, Brand = "Ford", Model = "Mustang" },
            new CarModel { Id = 10, Brand = "Dodge", Model = "Charger" },
            new CarModel { Id = 11, Brand = "Nissan", Model = "GTR" },
            new CarModel { Id = 12, Brand = "Honda", Model = "Civic" },
            new CarModel { Id = 13, Brand = "Toyota", Model = "Supra" },
            new CarModel { Id = 14, Brand = "Subaru", Model = "Impreza" },
            new CarModel { Id = 15, Brand = "Ferrari", Model = "488" }
        };

        // Seeding Cars
        modelBuilder.Entity<CarModel>().HasData(cars);

        Console.WriteLine($"Total Cars: {cars.Count}");

        var tickets = new List<TicketModel>()
        {
            new TicketModel { Id = 1, EntryTime = DateTime.Now, AmountPaid = 15, ExitTime = DateTime.Now + TimeSpan.FromHours(5) },
            new TicketModel { Id = 2, EntryTime = DateTime.Now, AmountPaid = 13, ExitTime = DateTime.Now + TimeSpan.FromHours(3) },
            new TicketModel { Id = 3, EntryTime = DateTime.Now, AmountPaid = 18, ExitTime = DateTime.Now + TimeSpan.FromHours(8) },
            new TicketModel { Id = 4, EntryTime = DateTime.Now, AmountPaid = 1, ExitTime = DateTime.Now + TimeSpan.FromHours(5) },
            new TicketModel { Id = 5, EntryTime = DateTime.Now, AmountPaid = 15, ExitTime = DateTime.Now + TimeSpan.FromHours(5) },
            new TicketModel { Id = 6, EntryTime = DateTime.Now, AmountPaid = 25, ExitTime = DateTime.Now + TimeSpan.FromHours(6) },
            new TicketModel { Id = 7, EntryTime = DateTime.Now, AmountPaid = 30, ExitTime = DateTime.Now + TimeSpan.FromHours(7) },
            new TicketModel { Id = 8, EntryTime = DateTime.Now, AmountPaid = 20, ExitTime = DateTime.Now + TimeSpan.FromHours(4) },
            new TicketModel { Id = 9, EntryTime = DateTime.Now, AmountPaid = 22, ExitTime = DateTime.Now + TimeSpan.FromHours(5) },
            new TicketModel { Id = 10, EntryTime = DateTime.Now, AmountPaid = 28, ExitTime = DateTime.Now + TimeSpan.FromHours(6) },
            new TicketModel { Id = 11, EntryTime = DateTime.Now, AmountPaid = 32, ExitTime = DateTime.Now + TimeSpan.FromHours(7) },
            new TicketModel { Id = 12, EntryTime = DateTime.Now, AmountPaid = 35, ExitTime = DateTime.Now + TimeSpan.FromHours(8) },
            new TicketModel { Id = 13, EntryTime = DateTime.Now, AmountPaid = 40, ExitTime = DateTime.Now + TimeSpan.FromHours(9) },
            new TicketModel { Id = 14, EntryTime = DateTime.Now, AmountPaid = 45, ExitTime = DateTime.Now + TimeSpan.FromHours(10) },
            new TicketModel { Id = 15, EntryTime = DateTime.Now, AmountPaid = 50, ExitTime = DateTime.Now + TimeSpan.FromHours(11) }
        };

        // Seeding Tickets
        modelBuilder.Entity<TicketModel>().HasData(tickets);

        Console.WriteLine($"Total Tickets: {tickets.Count}");
    }
}