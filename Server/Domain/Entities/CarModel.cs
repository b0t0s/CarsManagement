using Microsoft.EntityFrameworkCore;

namespace CarsManagement.Server.Domain.Entities;

[Owned]
public class CarModel
{
    public string Brand { get; set; }

    public string Model { get; set; }

    public string LicensePlate { get; set; }
}