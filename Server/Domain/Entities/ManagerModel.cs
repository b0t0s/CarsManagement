namespace CarsManagement.Server.Domain.Entities;

public class ManagerModel
{
    public int Id { get; set; }

    public string AccountName { get; set; }

    public string PasswordHash { get; set; }

    public ICollection<LotModel> ManagedParkingLots { get; set; }
}