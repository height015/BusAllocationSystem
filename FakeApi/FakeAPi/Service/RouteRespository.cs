using System;
using FakeAPi.Contract;
using FakeAPi.Response;
using XGrid.Contract;
using XGrid.Domain.Object;
using XGrid.Domain.Object.Data;
using XGrid.Repository;

namespace FakeAPi.Service
{
	public class RouteRespository : IRouteService
    {
        private readonly IRepository<RouteRegObj> _routeRepository;
        private ResponseObj _errorObj;
        public RouteRespository(AppDbContext appDbContext)
		{
            _routeRepository = new Repository<RouteRegObj>(appDbContext);
            _errorObj = new ResponseObj();
        }
        public async Task<RouteResponse> Create(RouteRegObj routeRegObj)
        {
            var response = new RouteResponse
            {
                IsSuccessful = false,
                RouteId = -1,
                ErrorResponse = new ResponseObj()
            };
            if (routeRegObj == null)
            {
                _errorObj.ErrorMessage = "Empty Data Object";
                _errorObj.TechMessage = "Empty Data Object";
                response.ErrorResponse = _errorObj;
            }
            try
            {
                if (routeRegObj == null)
                {
                    _errorObj.ErrorMessage = "Empty Data Object";
                    _errorObj.TechMessage = "Empty Data Object";
                    response.ErrorResponse = _errorObj;
                    return response;
                }
                var retVal = await _routeRepository.InsertAsync(routeRegObj);
                if (retVal == null || retVal.RouteObjId < 1)
                {
                    _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                    _errorObj.TechMessage = "Record counld not be updated";
                    response.ErrorResponse = _errorObj;
                    return response;
                }
                response.IsSuccessful = true;
                response.RouteId = retVal.RouteObjId;
                return response;
            }
            catch (Exception ex)
            {
                //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
                _errorObj.ErrorMessage = "Unknown Error Occurred!";
                _errorObj.TechMessage = ex.GetBaseException().Message;
                response.ErrorResponse = _errorObj;
                return response;

            }
        }

        public async Task<RouteResponse> Delete(int Id)
        {
            var response = new RouteResponse
            {
                IsSuccessful = false,
                RouteId = -1,
                ErrorResponse = new ResponseObj()
            };

            if (Id < 1)
            {
                _errorObj.ErrorMessage = "Invalid Id";
                _errorObj.TechMessage = "Invalid ID";
                response.ErrorResponse = _errorObj;
                return response;
            }
            try
            {
                var retVal = _routeRepository.Delete(Id);
                if (!string.IsNullOrEmpty(retVal))
                {
                    _errorObj.ErrorMessage = "Error Occurred! Could not Delete";
                    _errorObj.TechMessage = "Records could not be Deleted recods ";
                    response.ErrorResponse = _errorObj;
                }

                response.IsSuccessful = true;
                return await Task.FromResult(response);

            }
            catch (Exception ex)
            {
                _errorObj.ErrorMessage = "Unknown Error Occurred!";
                _errorObj.TechMessage = ex.GetBaseException().Message;
                //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
                response.ErrorResponse = _errorObj;
                return response;
            }
        }

        public async Task<RouteRegObj> Fetch(int Id)
        {

            var retVal = new RouteRegObj();
            var response = new RouteResponse
            {
                IsSuccessful = false,
                RouteId = -1,
                ErrorResponse = new ResponseObj()
            };

            if (Id <= 0)
            {
                _errorObj.ErrorMessage = "Error Occurred! invalid identity";
                _errorObj.TechMessage = "Records could not be fetch because " +
                    "Identity is less than or equals zero";
                response.ErrorResponse = _errorObj;
            }
            try
            {
                retVal = await _routeRepository.GetByIdAsync(Id);
                return retVal;
            }
            catch (Exception ex)
            {
                //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
                return retVal;
            }
        }

        public async Task<IEnumerable<RouteRegObj>> List()
        {
            var retVal = Enumerable.Empty<RouteRegObj>();
            try
            {
                retVal = await _routeRepository.FetchAsync();
                return retVal;
            }
            catch (Exception)
            {
                //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
                return retVal;
            }
        }

        public async Task<RouteResponse> Update(RouteRegObj routeRegObj)
        {
            var response = new RouteResponse
            {
                IsSuccessful = false,
                RouteId = -1,
                ErrorResponse = new ResponseObj()
            };
            try
            {
                if (routeRegObj == null)
                {
                    _errorObj.ErrorMessage = "Empty Data Object";
                    _errorObj.TechMessage = "Empty Data Object";
                    response.ErrorResponse = _errorObj;
                    return response;
                }
                var retVal = await _routeRepository.InsertAsync(routeRegObj);
                if (retVal == null || retVal.RouteObjId < 1)
                {
                    _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                    _errorObj.TechMessage = "Record counld not be updated";
                    response.ErrorResponse = _errorObj;
                    return response;
                }

                response.IsSuccessful = true;
                response.RouteId = retVal.RouteObjId;
                return response;

            }
            catch (Exception ex)
            {
                //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
                _errorObj.ErrorMessage = "Unknown Error Occurred!";
                _errorObj.TechMessage = ex.GetBaseException().Message;
                response.ErrorResponse = _errorObj;
                return response;
            }
        }
    }
}

