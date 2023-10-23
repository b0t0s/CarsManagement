namespace CarsManagement.Shared.DTO;

public class CarDTO
{
    public int CarId { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public string LicensePlate { get; set; }

    public TicketDTO Ticket { get; set; }
}