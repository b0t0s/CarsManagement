using System.Text;

namespace CarsManagement.Server.Domain.Entities;

public class CarModel
{
    public int Id { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public string LicensePlate { get; set; } =
        new StringBuilder(string.Format("#{0:X6}", new Random().Next(0x1000000))).ToString();

    public TicketModel Ticket { get; set; }
}