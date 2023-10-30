using Microsoft.EntityFrameworkCore;

namespace CarsManagement.Server.Domain.Entities;

[Owned]
public class TicketModel
{
    public DateTime EntryTime { get; set; }

    public DateTime? ExitTime { get; set; }

    public decimal AmountPaid { get; set; }
}