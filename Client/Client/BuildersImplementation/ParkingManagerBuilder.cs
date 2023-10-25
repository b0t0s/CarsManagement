using CarsManagement.Client.Application.Builders;
using CarsManagement.Shared.DTO;

namespace CarsManagement.Client.BuildersImplementation;

public class ParkingManagerBuilder : IParkingManagerBuilder<ManagerDTO, ParkingLotDTO>
{
    private ManagerDTO _manager = new();

    public IParkingManagerBuilder<ManagerDTO, ParkingLotDTO> SetUsername(string username)
    {
        _manager.AccountName = username;
        return this;
    }

    public IParkingManagerBuilder<ManagerDTO, ParkingLotDTO> SetLots(List<ParkingLotDTO> lots)
    {
        _manager.ManagedParkingLots = lots;
        return this;
    }

    public ManagerDTO Build()
    {
        return _manager;
    }

    public void Reset()
    {
        _manager = new ManagerDTO();
    }
}