using System;
using FakeAPi.Response;

namespace XGrid.Domain.Object;

public class ReservationRegObj
{
	public int ReservationObjId { get; set; }

    public int PassengerId { get; set; }
    public PassangerRegObj Passenger  { get; set; }

    public PassengerType PassengerType { get; set; }

    public int ExpectedNumber { get; set; }

    public int PickPointId { get; set; }
    public PickPointRegObj PickPoint { get; set; }
}

public class ReservationResponseObj
{
    public int ReservationId { get; set; }
    public bool isSuccess { get; set; }
    public ResponseObj ErrorResponse { get; set; }
}

