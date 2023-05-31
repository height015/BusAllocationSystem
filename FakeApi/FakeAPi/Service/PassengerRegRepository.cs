using FakeAPi.Contract;
using FakeAPi.Response;
using XGrid.Contract;
using XGrid.Domain.Object;
using XGrid.Domain.Object.Data;
using XGrid.Repository;

namespace FakeAPi.Service;

public class PassengerRegRepository : IPassengerService
{
    private readonly IRepository<PassangerRegObj> _passengerService;
    private ResponseObj _errorObj;

    public PassengerRegRepository(AppDbContext appDbContext)
	{
        _passengerService = new Repository<PassangerRegObj>(appDbContext);
        _errorObj = new ResponseObj();

    }

    public async Task<PassangerRegObj> Fetch(int id)
    {
        var retVal = new PassangerRegObj();
        var response = new PassangerResponseObj
        {
            IsSuccessful = false,
            PassengerId = -1,
            ErrorResponse = new ResponseObj()
        };

        try
        {
            if (id < 1)
            {
                _errorObj.ErrorMessage = "Error Occurred! invalid identity";
                _errorObj.TechMessage = "Records could not be fetch because " +
                    "Identity is less than or equals zero";
                response.ErrorResponse = _errorObj;
                return null;
            }

            retVal = await _passengerService.GetByIdAsync(id);
            return retVal;
        }
        catch (Exception ex)
        {
            return retVal;
        }
    }

    public async Task<PassangerResponseObj> Create(PassangerRegObj passangerRegObj)
    {
        var response = new PassangerResponseObj
        {
            IsSuccessful = false,
            PassengerId = -1,
            ErrorResponse = new ResponseObj()
        };

        try
        {
            if (passangerRegObj == null)
            {
                _errorObj.ErrorMessage = "Empty Data Object";
                _errorObj.TechMessage = "Empty Data Object";
                response.ErrorResponse = _errorObj;
                return response;
            }
            var retVal = await _passengerService.InsertAsync(passangerRegObj);
            if (retVal == null || retVal.PassangerRegObjId < 1)
            {
                _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                _errorObj.TechMessage = "Record counld not be updated";
                response.ErrorResponse = _errorObj;
                return response;
            }
            response.IsSuccessful = true;
            response.PassengerId = retVal.PassangerRegObjId;
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

    public async Task<PassangerResponseObj> Update(PassangerRegObj passangerRegObj)
    {
        var response = new PassangerResponseObj
        {
            IsSuccessful = false,
            PassengerId = -1,
            ErrorResponse = new ResponseObj()
        };
        try
        {
            if (passangerRegObj == null)
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

            var retVal = await _passengerService.InsertAsync(passangerRegObj);
            if (retVal == null || retVal.PassangerRegObjId < 1)
            {
                _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                _errorObj.TechMessage = "Record counld not be updated";
                response.ErrorResponse = _errorObj;
                return response;
            }

            response.IsSuccessful = true;
            response.PassengerId = retVal.PassangerRegObjId;
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

    public async Task<PassangerResponseObj> Delete(int Id)
    {
        var response = new PassangerResponseObj
        {
            IsSuccessful = false,
            PassengerId = -1,
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
            var retVal = _passengerService.Delete(Id);
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

    public async Task<IEnumerable<PassangerRegObj>> List()
    {
        var response = new PassangerResponseObj
        {
            IsSuccessful = false,
            PassengerId = -1,
            ErrorResponse = new ResponseObj()
        };

        var retVal = Enumerable.Empty<PassangerRegObj>();

        try
        {
            retVal = await _passengerService.FetchAsync();
            return retVal;
        }
        catch (Exception ex)
        {
            //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
            return retVal;
        }
    }
}

