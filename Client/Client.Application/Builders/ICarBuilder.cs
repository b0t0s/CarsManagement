namespace CarsManagement.Client.Application.Builders;

public interface ICarBuilder<T, F>
{
    ICarBuilder<T, F> SetId(int id);

    ICarBuilder<T, F> SetBrand(string brand);

    ICarBuilder<T, F> SetModel(string model);

    ICarBuilder<T, F> SetLicensePlate(string licensePlate);

    ICarBuilder<T, F> SetTicket(F ticket);

    T Build();

    void Reset();
}