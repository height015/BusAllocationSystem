using System;
using FakeAPi.Contract;
using FakeAPi.Response;
using XGrid.Contract;
using XGrid.Domain.Object;
using XGrid.Domain.Object.Data;
using XGrid.Repository;

namespace FakeAPi.Service
{
	public class PickPointRepository : IPickPointService
    {
        private readonly IRepository<PickPointRegObj> _pickUpPointRepository;
        private ResponseObj _errorObj;
        public PickPointRepository(AppDbContext appDbContext)
		{
            _pickUpPointRepository = new Repository<PickPointRegObj>(appDbContext);
            _errorObj = new ResponseObj();
        }

        public async Task<PickPointResponse> Create(PickPointRegObj routeRegObj)
        {
            var response = new PickPointResponse
            {
                PickPointId = -1,
                IsSuccessful = false,
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
                var retVal = await _pickUpPointRepository.InsertAsync(routeRegObj);
                if (retVal == null || retVal.PickPointObjId < 1)
                {
                    _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                    _errorObj.TechMessage = "Record counld not be updated";
                    response.ErrorResponse = _errorObj;
                    return response;
                }
                response.IsSuccessful = true;
                response.PickPointId = retVal.PickPointObjId;
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

        public async Task<PickPointResponse> Delete(int Id)
        {
            var response = new PickPointResponse
            {
                PickPointId = -1,
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
                var retVal = _pickUpPointRepository.Delete(Id);
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

        public async Task<PickPointRegObj> Fetch(int Id)
        {
            var retVal = new PickPointRegObj();
            var response = new PickPointResponse
            {
                PickPointId = -1,
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
                retVal = await _pickUpPointRepository.GetByIdAsync(Id);
                return retVal;
            }
            catch (Exception ex)
            {
                //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
                return retVal;
            }
        }

        public async Task<IEnumerable<PickPointRegObj>> List()
        {
           
            var retVal = Enumerable.Empty<PickPointRegObj>();

            try
            {
                retVal = await _pickUpPointRepository.FetchAsync();
                return retVal;
            }
            catch (Exception ex)
            {
                //ErrorUtilTools.LogErr(ex.StackTrace, ex.Source, ex.Message);
                return retVal;
            }
        }

        public async Task<PickPointResponse> Update(PickPointRegObj pickPointRegObj)
        {
            var response = new PickPointResponse
            {
                PickPointId = -1,
                IsSuccessful = false,
                ErrorResponse = new ResponseObj()
            };

            try
            {
                if (pickPointRegObj == null)
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

                var retVal = await _pickUpPointRepository.InsertAsync(pickPointRegObj);
                if (retVal == null || retVal.PickPointObjId < 1)
                {
                    _errorObj.ErrorMessage = "Error Occurred! Please try again later";
                    _errorObj.TechMessage = "Record counld not be updated";
                    response.ErrorResponse = _errorObj;
                    return response;
                }

                response.IsSuccessful = true;
                response.PickPointId = retVal.PickPointObjId;
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

