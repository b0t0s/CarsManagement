using System.Diagnostics;

namespace CarsManagement.Shared.DTO;

[DebuggerDisplay("{ToString(),nq}")]
public class CarDTO : BaseDTO
{
    public string Brand { get; set; }

    public string Model { get; set; }

    public string LicensePlate { get; set; }

    public TicketDTO Ticket { get; set; }

    public override string ToString()
    {
        return $"CarId: {Id}, Brand: {Brand}, Model: {Model}, LicensePlate: {LicensePlate}, Ticket: {Ticket}";
    }
}