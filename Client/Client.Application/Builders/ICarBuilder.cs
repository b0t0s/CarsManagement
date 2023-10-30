namespace CarsManagement.Client.Application.Builders;

public interface ICarBuilder<T, F>
{
    ICarBuilder<T, F> SetBrand(string brand);

    ICarBuilder<T, F> SetModel(string model);

    ICarBuilder<T, F> SetLicensePlate(string licensePlate);

    T Build();

    void Reset();
}