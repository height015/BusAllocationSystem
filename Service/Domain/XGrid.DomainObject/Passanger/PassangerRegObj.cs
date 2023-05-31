using System.ComponentModel.DataAnnotations;
using FakeAPi.Response;

namespace XGrid.Domain.Object;

public class PassangerRegObj
{
	public int PassangerRegObjId { get; set; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "First Name contains fewer or more characters than expected. (3 to 200 characters expected)")]
    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "Last Name contains fewer or more characters than expected. (3 to 200 characters expected)")]
    [Required(AllowEmptyStrings = false)]
    public string LastName { get; set; }

    [EmailAddress]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Last Name contains fewer or more characters than expected. (3 to 200 characters expected)")]
    [Required(AllowEmptyStrings = false)]
    public string EmailAddress { get; set; }

    public string Password { get; set; }

    [StringLength(10, MinimumLength = 10, ErrorMessage = "Date Of Birth contains fewer or more characters than expected. (10 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    [StringLength(15, MinimumLength = 9, ErrorMessage = "Phone Number contains fewer or more characters than expected. (9 to 15 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string PhoneNumber { get; set; }

}



public class PassangerObj
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public string DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    public string PhoneNumber { get; set; }

}

public class PassangerResponseObj
{
    public int PassengerId { get; set; }
    public bool IsSuccessful { get; set; }
    public ResponseObj ErrorResponse { get; set; }
}