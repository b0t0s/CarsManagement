using CarsManagement.Shared.DTO;

namespace CarsManagement.Shared.Extensions;

public static class LotExtensions
{
    public static List<int> GetAvailableSpotIds(this ParkingLotDTO lot)
    {
        return lot.ParkingSpots
            .Where(spot => !spot.IsOccupied)
            .Select(spot => spot.Id)
            .ToList();
    }
}