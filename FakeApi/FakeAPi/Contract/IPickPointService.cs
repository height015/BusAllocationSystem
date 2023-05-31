using System;
using XGrid.Domain.Object;

namespace FakeAPi.Contract;

public interface IPickPointService
{
    Task<PickPointRegObj> Fetch(int id);

    Task<PickPointResponse> Create(PickPointRegObj routeRegObj);

    Task<PickPointResponse> Update(PickPointRegObj routeRegObj);

    Task<PickPointResponse> Delete(int Id);

    Task<IEnumerable<PickPointRegObj>> List();
}

