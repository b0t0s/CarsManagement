using System.Diagnostics;

namespace CarsManagement.Shared.DTO;

[DebuggerDisplay("{ToString(),nq}")]
public class TicketDTO
{
    public decimal AmountPaid { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime ExitTime { get; set; }

    public override string ToString()
    {
        return $"AmountPaid: {AmountPaid}, EntryTime: {EntryTime}, ExitTime: {ExitTime}";
    }
}