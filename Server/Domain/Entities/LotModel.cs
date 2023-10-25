namespace CarsManagement.Server.Domain.Entities;

public class LotModel
{
    public int Id { get; set; }

    public int ManagerId { get; set; }

    public string LotName { get; set; }

    public string LotLocation { get; set; }

    public List<SpotModel> ParkingSpots { get; set; } = new();
}