namespace CarsManagement.Shared.DTO;

public class TicketDTO
{
    public int Id { get; set; }

    public decimal AmountPaid { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime? ExitTime { get; set; }

}