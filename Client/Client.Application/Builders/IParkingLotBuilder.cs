namespace CarsManagement.Client.Application.Builders;

public interface IParkingLotBuilder<T, F>
{
    IParkingLotBuilder<T, F> SetLotId(int lotId);

    IParkingLotBuilder<T, F> SetManagerId(int managerId);

    IParkingLotBuilder<T, F> SetLotName(string lotName);

    IParkingLotBuilder<T, F> SetLotLocation(string lotLocation);

    IParkingLotBuilder<T, F> SetLotsSpots(List<F> lotSpots);

    T Build();

    void Reset();
}