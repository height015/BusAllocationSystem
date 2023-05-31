using FakeAPi.Contract;
using FakeAPi.Response;
using XGrid.Contract;
using XGrid.Domain.Object;
using XGrid.Domain.Object.Data;
using XGrid.Repository;

namespace FakeAPi.Service;

public class BusRegistrationRepository : IBusService
{
    private readonly IRepository<BusRegistrationObj> _busRegRepository;
    private ResponseObj _errorObj;
    public BusRegistrationRepository(AppDbContext appDbContext)
	{
        _busRegRepository = new Repository<BusRegistrationObj>(appDbContext);
        _errorObj = new ResponseObj();
    }

    public async Task<BusRegistrationResponseObj> Create(BusRegistrationObj busRegistrationObj)
    {
        var response = new BusRegistrationResponseObj
        {
            IsSuccess = false,
            BusRegistrationId = 0,
            ErrorResponse = new ResponseObj()
        };
        try
        {
            if (busRegistrationObj == null)
            {
                _errorObj.ErrorMessage = "Empty Data Object";
                _errorObj.TechMessage = "Empty Data Object";
                response.ErrorResponse = _errorObj;
                return response;
            }
            var retVal = await _busRegRepository.InsertAsync(busRegistrationObj);
            if (retVal == null || retVal.BusRegistrationObjId < 1)
            {
                _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                _errorObj.TechMessage = "Record counld not be updated";
                response.ErrorResponse = _errorObj;
                return response;
            }
            response.IsSuccess = true;
            response.BusRegistrationId = retVal.BusRegistrationObjId;
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
    public async Task<BusRegistrationResponseObj> Delete(int Id)
    {
        var response = new BusRegistrationResponseObj
        {
            IsSuccess = false,
            BusRegistrationId = 0,
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
                var retVal = _busRegRepository.Delete(Id);
                if (!string.IsNullOrEmpty(retVal))
                {
                    _errorObj.ErrorMessage = "Error Occurred! Could not Delete";
                    _errorObj.TechMessage = "Records could not be Deleted recods ";
                    response.ErrorResponse = _errorObj;
                }

                response.IsSuccess = true;
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

    public async Task<BusRegistrationObj> Fetch(int Id)
    {
        var retVal = new BusRegistrationObj();
        var response = new BusRegistrationResponseObj
        {
            IsSuccess = false,
            BusRegistrationId = 0,
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
            retVal = await _busRegRepository.GetByIdAsync(Id);
            return retVal;
        }
        catch (Exception ex)
        {
            //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
            return retVal;
        }

    }

    public async Task<IEnumerable<BusRegistrationObj>> List()
    {

        var retVal = Enumerable.Empty<BusRegistrationObj>();

        try
        {
            retVal = await _busRegRepository.FetchAsync();
            return retVal;
        }
        catch (Exception ex)
        {
            //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
            return retVal;
        }
    }

    public async Task<BusRegistrationResponseObj> Update(BusRegistrationObj busRegistrationObj)
    {
        var response = new BusRegistrationResponseObj
        {
            IsSuccess = false,
            BusRegistrationId = 0,
            ErrorResponse = new ResponseObj()
        };

        try
        {
            if (busRegistrationObj == null)
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

            var retVal = await _busRegRepository.InsertAsync(busRegistrationObj);
            if (retVal == null || retVal.BusRegistrationObjId < 1)
            {
                _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                _errorObj.TechMessage = "Record counld not be updated";
                response.ErrorResponse = _errorObj;
                return response;
            }

            response.IsSuccess = true;
            response.BusRegistrationId = retVal.BusRegistrationObjId;
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

