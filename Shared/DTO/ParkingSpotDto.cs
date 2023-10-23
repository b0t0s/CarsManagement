namespace CarsManagement.Shared.DTO;

public class ParkingSpotDTO
{
    public int SpotId { get; set; }

    public bool IsOccupied { get; set; }

    public bool IsInclusive { get; set; }

    public CarDTO? ParkedCar { get; set; }
}