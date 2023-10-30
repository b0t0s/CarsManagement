using System.ComponentModel.DataAnnotations;

namespace CarsManagement.Client.Application;

public class ParkingLotModel
{
    [Required(ErrorMessage = "Lot Name is required")]
    [StringLength(100, ErrorMessage = "Lot Name is too long")]
    public string LotName { get; set; }

    [Required(ErrorMessage = "Lot Location is required")]
    [StringLength(100, ErrorMessage = "Lot Location is too long")]
    public string LotLocation { get; set; }

    [Required(ErrorMessage = "Number of spots is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Number of spots must be greater than 0")]
    public int SpotCount { get; set; }
}
