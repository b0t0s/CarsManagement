using System.Diagnostics;

namespace CarsManagement.Shared.DTO;

[DebuggerDisplay("{ToString(),nq}")]
public class ParkingLotDTO : BaseDTO
{
    public int LotId { get; set; }

    public int ManagerId { get; set; }

    public string LotName { get; set; }

    public string LotLocation { get; set; }

    public List<ParkingSpotDTO> ParkingSpots { get; set; } = new();

    public override string ToString()
    {
        return
            $"LotId: {LotId}, ManagerId: {ManagerId}, LotName: {LotName}, LotLocation: {LotLocation}, ParkingSpots: {string.Join(", ", ParkingSpots)}";
    }
}