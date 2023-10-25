using CarsManagement.Client.Application.Builders;
using CarsManagement.Shared.DTO;

namespace CarsManagement.Client.BuildersImplementation;

public class ParkingSpotBuilder : IParkingSpotBuilder<ParkingSpotDTO>
{
    private ParkingSpotDTO _parkingSpot = new();

    public IParkingSpotBuilder<ParkingSpotDTO> SetSpotId(int spotId)
    {
        _parkingSpot.Id = spotId;
        return this;
    }

    public IParkingSpotBuilder<ParkingSpotDTO> SetIsInclusive(bool isInclusive)
    {
        _parkingSpot.IsInclusive = isInclusive;
        return this;
    }

    public ParkingSpotDTO Build()
    {
        return _parkingSpot;
    }

    public void Reset()
    {
        _parkingSpot = new ParkingSpotDTO();
    }
}