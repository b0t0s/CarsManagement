namespace CarsManagement.Client.Application.Builders;

public interface IParkingSpotBuilder<T, F, L>
{
    IParkingSpotBuilder<T, F, L> SetSpotId(int spotId);

    IParkingSpotBuilder<T, F, L> SetOccupied(bool isOccupied);

    IParkingSpotBuilder<T, F, L> SetCar(F car);

    IParkingSpotBuilder<T, F, L> SetTicket(L ticket);

    T Build();

    void Reset();
}