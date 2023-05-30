using System;
using System.ComponentModel.DataAnnotations;

namespace XGrid.Domain.Object;

public class RouteCordinatorRegObj
{
	public int RouteCordinatorRegObjId { get; set; }

    [StringLength(25, MinimumLength = 3, ErrorMessage = "First Name contains fewer or more characters than expected. (3 to 25 characters are expected)")]
    [Required(AllowEmptyStrings = false)]

    public string FirstName { get; set; }
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Last Name contains fewer or more characters than expected. (3 to 25 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string LastName { get; set; }

    [StringLength(9, MinimumLength = 15, ErrorMessage = "Phone Number contains fewer or more characters than expected. (9 to 15 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string PhoneNumber { get; set; }

    [StringLength(9, MinimumLength = 25, ErrorMessage = "Address contains fewer or more characters than expected. (9 to 25 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string Address { get; set; }

}

