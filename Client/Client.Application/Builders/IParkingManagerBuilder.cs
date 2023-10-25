namespace CarsManagement.Client.Application.Builders;

public interface IParkingManagerBuilder<T, F>
{
    IParkingManagerBuilder<T, F> SetUsername(string username);

    IParkingManagerBuilder<T, F> SetLots(List<F> lotSpots);

    T Build();

    void Reset();
}