namespace CarsManagement.Client.Application.Builders;

public interface IParkingSpotBuilder<T>
{
    IParkingSpotBuilder<T> SetSpotId(int spotId);

    IParkingSpotBuilder<T> SetIsInclusive(bool isInclusive);

    T Build();

    void Reset();
}