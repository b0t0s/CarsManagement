using System.ComponentModel.DataAnnotations;

namespace CarsManagement.Client;

public class ParkingModel
{
    [Required(ErrorMessage = "Please select a parking lot.")]
    public string SelectedLot { get; set; }

    [Required(ErrorMessage = "Please select a parking spot.")]
    public int SelectedSpot { get; set; }

    [Required(ErrorMessage = "Please enter the car's brand.")]
    public string Brand { get; set; }

    [Required(ErrorMessage = "Please enter the car's model.")]
    public string Model { get; set; }

    [Required(ErrorMessage = "Please enter the license plate.")]
    public string LicensePlate { get; set; }

    [Required(ErrorMessage = "Please select the exit date.")]
    public DateTime ExitTime { get; set; }
}
