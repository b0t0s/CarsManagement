using CarsManagement.Client.Application.Builders;
using CarsManagement.Shared.DTO;

namespace CarsManagement.Client.BuildersImplementation;

public class ParkingLotBuilder : IParkingLotBuilder<ParkingLotDTO, ParkingSpotDTO>
{
    private ParkingLotDTO _parkingLot = new();

    public IParkingLotBuilder<ParkingLotDTO, ParkingSpotDTO> SetLotId(int lotId)
    {
        _parkingLot.LotId = lotId;
        return this;
    }

    public IParkingLotBuilder<ParkingLotDTO, ParkingSpotDTO> SetManagerId(int managerId)
    {
        _parkingLot.ManagerId = managerId;
        return this;
    }

    public IParkingLotBuilder<ParkingLotDTO, ParkingSpotDTO> SetLotName(string lotName)
    {
        _parkingLot.LotName = lotName;
        return this;
    }

    public IParkingLotBuilder<ParkingLotDTO, ParkingSpotDTO> SetLotLocation(string lotLocation)
    {
        _parkingLot.LotLocation = lotLocation;
        return this;
    }

    public IParkingLotBuilder<ParkingLotDTO, ParkingSpotDTO> SetLotsSpots(List<ParkingSpotDTO> lotSpots)
    {
        _parkingLot.ParkingSpots = lotSpots;
        return this;
    }

    public ParkingLotDTO Build()
    {
        return _parkingLot;
    }

    public void Reset()
    {
        _parkingLot = new ParkingLotDTO();
    }
}