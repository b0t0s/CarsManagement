namespace CarsManagement.Shared.DTO;

public class ManagerDTO
{
    public int ManagerId { get; set; }

    public string AccountName { get; set; }

    public ICollection<ParkingLotDTO> ManagedParkingLots { get; set; } = new List<ParkingLotDTO>();
}
