using CarsManagement.Client.Application.Builders;
using CarsManagement.Shared.DTO;

namespace CarsManagement.Client.BuildersImplementation;

public class CarBuilder : ICarBuilder<CarDTO, TicketDTO>
{
    private CarDTO _car = new();

    public ICarBuilder<CarDTO, TicketDTO> SetId(int spotId)
    {
        _car.Id = spotId;
        return this;
    }

    public ICarBuilder<CarDTO, TicketDTO> SetBrand(string brand)
    {
        _car.Brand = brand;
        return this;
    }

    public ICarBuilder<CarDTO, TicketDTO> SetModel(string model)
    {
        _car.Model = model;
        return this;
    }

    public ICarBuilder<CarDTO, TicketDTO> SetLicensePlate(string licensePlate)
    {
        _car.LicensePlate = licensePlate;
        return this;
    }

    public ICarBuilder<CarDTO, TicketDTO> SetTicket(TicketDTO ticket)
    {
        _car.Ticket = ticket;
        return this;
    }

    public CarDTO Build()
    {
        return _car;
    }

    public void Reset()
    {
        _car = new CarDTO();
    }
}