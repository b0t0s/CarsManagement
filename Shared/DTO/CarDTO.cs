using System.Diagnostics;

namespace CarsManagement.Shared.DTO;

[DebuggerDisplay("{ToString(),nq}")]
public class CarDTO
{
    public string Brand { get; set; }

    public string Model { get; set; }

    public string LicensePlate { get; set; }

    public override string ToString()
    {
        return $"Brand: {Brand}, Model: {Model}, LicensePlate: {LicensePlate}";
    }
}