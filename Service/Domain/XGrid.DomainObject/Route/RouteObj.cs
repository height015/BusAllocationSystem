using System;
using System.ComponentModel.DataAnnotations;
using FakeAPi.Response;

namespace XGrid.Domain.Object;

public class RouteRegObj
{
    public RouteRegObj()
    {
        PickPoint = new HashSet<PickPointRegObj>();
    }
    public int RouteObjId { get; set; }

    [StringLength(90, MinimumLength = 3, ErrorMessage = "Route Name contains fewer or more characters than expected. (3 to 90 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string RouteName { get; set; }

    [StringLength(90, MinimumLength = 3, ErrorMessage = "Distance contains fewer or more characters than expected. (3 to 90 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public double Distance { get; set; }

    [StringLength(90, MinimumLength = 3, ErrorMessage = "Travel Time contains fewer or more characters than expected. (3 to 90 characters are expected)")]
    [Required(AllowEmptyStrings = false)]

    public string TravelTime { get; set; }

    public string Stops { get; set; }

    public int BusId { get; set; }
    public BusRegistrationObj AssignedBus { get; set; }

    public int RouteCordinatorId { get; set; }
    public RouteCordinatorRegObj RouteCordinator { get; set; }

    public string Schedule { get; set; }

    [StringLength(10, MinimumLength = 10, ErrorMessage = "Start Date contains fewer or more characters than expected. (10 to 10 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string StartDate { get; set; }

    [StringLength(10, MinimumLength = 10, ErrorMessage = "End Date contains fewer or more characters than expected. (10 to 10 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string EndDate { get; set; }

    [StringLength(500, MinimumLength = 5, ErrorMessage = "Aditional Notes contains fewer or more characters than expected. (5 to 500 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string AditionalNotes { get; set; }

    public ICollection<PickPointRegObj> PickPoint { get; set; }
}


public class RouteObj
{
 
    public int RouteObjId { get; set; }

    public string RouteName { get; set; }

    public double Distance { get; set; }

    public string TravelTime { get; set; }

    public string Stops { get; set; }

    public int BusId { get; set; }
    public BusRegistrationObj AssignedBus { get; set; }

    public int RouteCordinatorId { get; set; }
    public RouteCordinatorRegObj RouteCordinator { get; set; }

    public string Schedule { get; set; }


    public string StartDate { get; set; }


    public string EndDate { get; set; }


    public string AditionalNotes { get; set; }

    public ICollection<PickPointRegObj> PickPoint { get; set; }
}

public class RouteResponse
{
    public int RouteId { get; set; }
    public bool IsSuccessful { get; set; }
    public ResponseObj ErrorResponse { get; set; }
}

public class PickPointRegObj
{
    public int PickPointObjId { get; set; }
    [StringLength(90, MinimumLength = 3, ErrorMessage = "Name contains fewer or more characters than expected. (3 to 90 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; }

    [StringLength(90, MinimumLength = 3, ErrorMessage = "Location contains fewer or more characters than expected. (3 to 90 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string Location { get; set; }

    [StringLength(300, MinimumLength = 5, ErrorMessage = "Description contains fewer or more characters than expected. (5 to 300 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string Description { get; set; }

    public string PicupTime { get; set; }

    [StringLength(30, MinimumLength = 3, ErrorMessage = "Wait Time contains fewer or more characters than expected. (3 to 30 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string WaitTime { get; set; }
}


public class PickPointObj
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public string Description { get; set; }

    public string PicupTime { get; set; }

    public string WaitTime { get; set; }
}

public class PickPointResponse
{
    public int PickPointId { get; set; }
    public bool IsSuccessful { get; set; }
    public ResponseObj ErrorResponse { get; set; }
}


