using System.Diagnostics;

namespace CarsManagement.Shared.DTO;

[DebuggerDisplay("{ToString(),nq}")]
public class ParkingSpotDTO : BaseDTO
{
    public bool IsOccupied { get; set; }

    public CarDTO? ParkedCar { get; set; }

    public TicketDTO? Ticket { get; set; }

    public override string ToString()
    {
        return $"SpotId: {Id}, IsOccupied: {IsOccupied}, ParkedCar: {ParkedCar}, TicketInfo: {Ticket}";
    }
}