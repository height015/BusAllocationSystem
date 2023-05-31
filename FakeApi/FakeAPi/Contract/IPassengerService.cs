using System;
using XGrid.Domain.Object;

namespace FakeAPi.Contract;

public interface IPassengerService
{
    Task<PassangerRegObj> Fetch(int id);

    Task<PassangerResponseObj> Create(PassangerRegObj passangerRegObj);

    Task<PassangerResponseObj> Update(PassangerRegObj passangerRegObj);

    Task<PassangerResponseObj> Delete(int Id);

    Task<IEnumerable<PassangerRegObj>> List();
}



