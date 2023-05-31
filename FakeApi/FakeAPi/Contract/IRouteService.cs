using System;
using XGrid.Domain.Object;

namespace FakeAPi.Contract;

public interface IRouteService
{
    Task<RouteRegObj> Fetch(int id);

    Task<RouteResponse> Create(RouteRegObj routeRegObj);

    Task<RouteResponse> Update(RouteRegObj routeRegObj);

    Task<RouteResponse> Delete(int Id);

    Task<IEnumerable<RouteRegObj>> List();

}

