using System;
using System.ComponentModel.DataAnnotations;

namespace XGrid.Domain.Object;

public class BusRegistrationObj 
{
    public int BusRegistrationObjId { get; set; }

    [StringLength(90, MinimumLength = 3, ErrorMessage = "Name contains fewer or more characters than expected. (3 to 90 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; }

    [StringLength(3, MinimumLength = 15, ErrorMessage = "Color contains fewer or more characters than expected. (3 to 15 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string Color { get; set; }

    [StringLength(3, MinimumLength = 15, ErrorMessage = "Bus Model contains fewer or more characters than expected. (3 to 15 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string BusModel { get; set; }

    [StringLength(3, MinimumLength = 15, ErrorMessage = "Bus Manufactural contains fewer or more characters than expected. (3 to 15 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string BusManufactural { get; set; }

    [StringLength(10, MinimumLength = 10, ErrorMessage = "ManufactureYear contains fewer or more characters than expected. (10 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string ManufactureYear { get; set; }
    [Range(minimum:1, maximum:35)]
    public int SeatCapacity { get; set; }

    [StringLength(20, MinimumLength = 3, ErrorMessage = "Fuel Type contains fewer or more characters than expected. (3 to 20 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string FuelType { get; set; }

    [StringLength(25, MinimumLength = 6, ErrorMessage = "Licence Plate contains fewer or more characters than expected. (6 to 25 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string LicencePlate { get; set; }

    [StringLength(10, MinimumLength = 10, ErrorMessage = "Registration Date contains fewer or more characters than expected. (10 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string RegistrationDate { get; set; }

    [StringLength(9, MinimumLength = 15, ErrorMessage = "Driver Phone Number contains fewer or more characters than expected. (9 to 15 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string DriverPhoneNumber { get; set; }

    public BusType BusType { get; set; }

    [StringLength(500, MinimumLength = 5, ErrorMessage = "Additional Information contains fewer or more characters than expected. (5 to 500 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string AdditionalInformation { get; set; }

}
