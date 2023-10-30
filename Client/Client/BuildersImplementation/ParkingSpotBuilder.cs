using CarsManagement.Client.Application.Builders;
using CarsManagement.Shared.DTO;

namespace CarsManagement.Client.BuildersImplementation;

public class ParkingSpotBuilder : IParkingSpotBuilder<ParkingSpotDTO, CarDTO, TicketDTO>
{
    private ParkingSpotDTO _parkingSpot = new();

    public IParkingSpotBuilder<ParkingSpotDTO, CarDTO, TicketDTO> SetSpotId(int spotId)
    {
        _parkingSpot.Id = spotId;
        return this;
    }

    public IParkingSpotBuilder<ParkingSpotDTO, CarDTO, TicketDTO> SetOccupied(bool isOccupied)
    {
        _parkingSpot.IsOccupied = isOccupied;
        return this;
    }

    public IParkingSpotBuilder<ParkingSpotDTO, CarDTO, TicketDTO> SetCar(CarDTO car)
    {
        _parkingSpot.ParkedCar = car;
        return this;
    }

    public IParkingSpotBuilder<ParkingSpotDTO, CarDTO, TicketDTO> SetTicket(TicketDTO ticket)
    {
        _parkingSpot.Ticket = ticket;
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