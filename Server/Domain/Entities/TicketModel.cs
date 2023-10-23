namespace CarsManagement.Server.Domain.Entities;

public class TicketModel
{
    public int Id { get; set; }

    public CarModel Car { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime? ExitTime { get; set; }

    public decimal AmountPaid { get; set; }
}