namespace CarsManagement.Server.Domain.Entities;

public class SpotModel
{
    public int Id { get; set; }

    public int LotId { get; set; }

    public bool IsOccupied { get; set; }

    public bool IsInclusive { get; set; }

    public CarModel? ParkedCar { get; set; }
}