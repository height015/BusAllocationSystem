using System;
using XGrid.Domain.Object;

namespace FakeAPi.Contract;

public interface IRouteCordinatorService
{

    Task<RouteCordinatorRegObj> Fetch(int id);

    Task<RouteCordinatorResponse> Create(RouteCordinatorRegObj routeCordinatorRegObj);

    Task<RouteCordinatorResponse> Update(RouteCordinatorRegObj routeCordinatorRegObj);

    Task<RouteCordinatorResponse> Delete(int Id);

    Task<IEnumerable<RouteCordinatorRegObj>> List();



}

