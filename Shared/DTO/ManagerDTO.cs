using System.Diagnostics;

namespace CarsManagement.Shared.DTO;

[DebuggerDisplay("{ToString(),nq}")]
public class ManagerDTO : BaseDTO
{
    public int ManagerId { get; set; }

    public string AccountName { get; set; }

    public ICollection<ParkingLotDTO> ManagedParkingLots { get; set; }

    public override string ToString()
    {
        return
            $"ManagerId: {ManagerId}, AccountName: {AccountName}, ManagedParkingLots: {string.Join(", ", ManagedParkingLots)}";
    }
}