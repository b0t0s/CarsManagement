namespace CarsManagement.Shared.DTO;

public class ParkingLotDTO
{
    public int LotId { get; set; }

    public int ManagerId { get; set; }

    public string LotName { get; set; }

    public string LotLocation { get; set; }

    public List<ParkingSpotDTO> ParkingSpots { get; set; } = new List<ParkingSpotDTO>();
}