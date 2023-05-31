using System;
using XGrid.Domain.Object;

namespace FakeAPi.Contract;


public interface IBusService
{

    Task<BusRegistrationObj> Fetch(int id);

    Task<BusRegistrationResponseObj> Create(BusRegistrationObj busRegistrationObj);

    Task<BusRegistrationResponseObj> Update(BusRegistrationObj busRegistrationObj);

    Task<BusRegistrationResponseObj> Delete(int Id);

    Task<IEnumerable<BusRegistrationObj>> List();


}

