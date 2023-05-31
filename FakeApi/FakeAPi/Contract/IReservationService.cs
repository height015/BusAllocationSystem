using System;
using XGrid.Domain.Object;

namespace FakeAPi.Contract;

public interface IReservationService
{
    Task<ReservationRegObj> Fetch(int id);

    Task<ReservationResponseObj> Create(ReservationRegObj reservationRegObj);

    Task<ReservationResponseObj> Update(ReservationRegObj reservationRegObj);

    Task<ReservationResponseObj> Delete(int Id);

    Task<IEnumerable<ReservationRegObj>> List();
}

