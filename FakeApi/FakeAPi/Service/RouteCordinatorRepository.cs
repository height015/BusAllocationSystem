using System;
using FakeAPi.Contract;
using FakeAPi.Response;
using XGrid.Contract;
using XGrid.Domain.Object;
using XGrid.Domain.Object.Data;
using XGrid.Repository;

namespace FakeAPi.Service;

public class RouteCordinatorRepository : IRouteCordinatorService
{
    private readonly IRepository<RouteCordinatorRegObj> _routeCordinatorRepository;
    private ResponseObj _errorObj;

	public RouteCordinatorRepository(AppDbContext appDbContext)
	{
        _routeCordinatorRepository = new Repository<RouteCordinatorRegObj>(appDbContext);
        _errorObj = new ResponseObj();
    }

    public async Task<RouteCordinatorResponse> Create(RouteCordinatorRegObj routeCordinatorRegObj)
    {
        var response = new RouteCordinatorResponse
        {
            RouteCordinatorId = -1,
            IsSuccessful = false,
            ErrorResponse = new ResponseObj()
        };

        if (routeCordinatorRegObj == null)
        {
            _errorObj.ErrorMessage = "Empty Data Object";
            _errorObj.TechMessage = "Empty Data Object";
            response.ErrorResponse = _errorObj;
        }
        try
        {
            if (routeCordinatorRegObj == null)
            {
                _errorObj.ErrorMessage = "Empty Data Object";
                _errorObj.TechMessage = "Empty Data Object";
                response.ErrorResponse = _errorObj;
                return response;
            }
            var retVal = await _routeCordinatorRepository.InsertAsync(routeCordinatorRegObj);
            if (retVal == null || retVal.RouteCordinatorRegObjId < 1)
            {
                _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                _errorObj.TechMessage = "Record counld not be updated";
                response.ErrorResponse = _errorObj;
                return response;
            }
            response.IsSuccessful = true;
            response.RouteCordinatorId = retVal.RouteCordinatorRegObjId;
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

    public async Task<RouteCordinatorResponse> Delete(int Id)
    {
        var response = new RouteCordinatorResponse
        {
            RouteCordinatorId = -1,
            IsSuccessful = false,
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
            var retVal = _routeCordinatorRepository.Delete(Id);
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

    public async Task<RouteCordinatorRegObj> Fetch(int Id)
    {
        var retVal = new RouteCordinatorRegObj();
        var response = new RouteCordinatorResponse
        {
            RouteCordinatorId = -1,
            IsSuccessful = false,
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
            retVal = await _routeCordinatorRepository.GetByIdAsync(Id);
            return retVal;
        }
        catch (Exception ex)
        {
            //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
            return retVal;
        }
    }

    public async Task<IEnumerable<RouteCordinatorRegObj>> List()
    {
        var retVal = Enumerable.Empty<RouteCordinatorRegObj>();
        try
        {
            retVal = await _routeCordinatorRepository.FetchAsync();
            return retVal;
        }
        catch (Exception)
        {
            //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
            return retVal;
        }
    }

    public async Task<RouteCordinatorResponse> Update(RouteCordinatorRegObj routeCordinatorRegObj)
    {
        var response = new RouteCordinatorResponse
        {
            RouteCordinatorId = -1,
            IsSuccessful = false,
            ErrorResponse = new ResponseObj()
        };
        try
        {
            if (routeCordinatorRegObj == null)
            {
                _errorObj.ErrorMessage = "Empty Data Object";
                _errorObj.TechMessage = "Empty Data Object";
                response.ErrorResponse = _errorObj;
                return response;
            }

            //if (!universityObj.ObjValid(out var msg))
            //{
            //    _errorObj.ErrorMessage = $"Validation Error Occured! Details: {msg}";
            //    response.ResponseError = _errorObj;
            //    return response;
            //}

            var retVal = await _routeCordinatorRepository.InsertAsync(routeCordinatorRegObj);
            if (retVal == null || retVal.RouteCordinatorRegObjId < 1)
            {
                _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                _errorObj.TechMessage = "Record counld not be updated";
                response.ErrorResponse = _errorObj;
                return response;
            }

            response.IsSuccessful = true;
            response.RouteCordinatorId = retVal.RouteCordinatorRegObjId;
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

