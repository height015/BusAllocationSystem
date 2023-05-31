using FakeAPi.Contract;
using FakeAPi.Response;
using XGrid.Contract;
using XGrid.Domain.Object;
using XGrid.Domain.Object.Data;
using XGrid.Repository;

namespace FakeAPi.Service;

public class ReservationRepository : IReservationService{

    private readonly IRepository<ReservationRegObj> _reservationRepository;
    private ResponseObj _errorObj;
    public ReservationRepository(AppDbContext appDbContext)
	{
        _reservationRepository = new Repository<ReservationRegObj>(appDbContext);
        _errorObj = new ResponseObj();
    }

    public async Task<ReservationResponseObj> Create(ReservationRegObj reservationRegObj)
    {
        var response = new ReservationResponseObj
        {
            isSuccess = false,
            ReservationId = -1,
            ErrorResponse = new ResponseObj()
        };

        try
        {
            if (reservationRegObj == null)
            {
                _errorObj.ErrorMessage = "Empty Data Object";
                _errorObj.TechMessage = "Empty Data Object";
                response.ErrorResponse = _errorObj;
                return response;
            }
            var retVal = await _reservationRepository.InsertAsync(reservationRegObj);
            if (retVal == null || retVal.ReservationObjId < 1)
            {
                _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                _errorObj.TechMessage = "Record counld not be updated";
                response.ErrorResponse = _errorObj;
                return response;
            }
            response.isSuccess = true;
            response.ReservationId = retVal.ReservationObjId;
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

    public async Task<ReservationResponseObj> Delete(int Id)
    {
        var response = new ReservationResponseObj
        {
            isSuccess = false,
            ReservationId = -1,
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
            var retVal = _reservationRepository.Delete(Id);
            if (!string.IsNullOrEmpty(retVal))
            {
                _errorObj.ErrorMessage = "Error Occurred! Could not Delete";
                _errorObj.TechMessage = "Records could not be Deleted recods ";
                response.ErrorResponse = _errorObj;
            }

            response.isSuccess = true;
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

    public async Task<ReservationRegObj> Fetch(int Id)
    {
        var retVal = new ReservationRegObj();
        var response = new ReservationResponseObj
        {
            isSuccess = false,
            ReservationId = -1,
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
            retVal = await _reservationRepository.GetByIdAsync(Id);
            return retVal;
        }
        catch (Exception ex)
        {
            //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
            return retVal;
        }

    }

    public async Task<IEnumerable<ReservationRegObj>> List()
    {

        var retVal = Enumerable.Empty<ReservationRegObj>();

        try
        {
            retVal = await _reservationRepository.FetchAsync();
            return retVal;
        }
        catch (Exception ex)
        {
            //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
            return retVal;
        }
    }

    public async Task<ReservationResponseObj> Update(ReservationRegObj reservationRegObj)
    {
        var response = new ReservationResponseObj
        {
            isSuccess = false,
            ReservationId = -1,
            ErrorResponse = new ResponseObj()
        };

        try
        {
            if (reservationRegObj == null)
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

            var retVal = await _reservationRepository.InsertAsync(reservationRegObj);
            if (retVal == null || retVal.ReservationObjId < 1)
            {
                _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                _errorObj.TechMessage = "Record counld not be updated";
                response.ErrorResponse = _errorObj;
                return response;
            }

            response.isSuccess = true;
            response.ReservationId = retVal.ReservationObjId;
            return response;

        }
        catch (Exception ex)
        {
            _errorObj.ErrorMessage = "Unknown Error Occurred!";
            _errorObj.TechMessage = ex.GetBaseException().Message;
            response.ErrorResponse = _errorObj;

            return response;
        }
    }
}

