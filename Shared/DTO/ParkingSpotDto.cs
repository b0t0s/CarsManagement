using System.Diagnostics;

namespace CarsManagement.Shared.DTO;

[DebuggerDisplay("{ToString(),nq}")]
public class ParkingSpotDTO : BaseDTO
{
    public bool IsOccupied { get; set; }

    public bool IsInclusive { get; set; }

    public CarDTO? ParkedCar { get; set; }

    public override string ToString()
    {
        return $"SpotId: {Id}, IsOccupied: {IsOccupied}, IsInclusive: {IsInclusive}, ParkedCar: {ParkedCar}";
    }
}