using System;
using FakeAPi.Contract;

namespace FakeAPi.Controllers;

public class PassengerController : BaseApiController
{
    private readonly IPassengerService _passengerService;

    public PassengerController(IPassengerService passengerService){
        _passengerService = passengerService;
    }






}

