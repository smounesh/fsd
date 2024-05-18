using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeRequestTrackerAPI.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
    
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
  
        }

        [HttpPost]
        [Route("RaiseRequest")]
        [ProducesResponseType(typeof(RaiseRequestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> RaiseRequest(RaiseRequestDTO raiseRequestDTO)
        {
            try
            {
                int empId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "empId")?.Value);
                if (raiseRequestDTO.UserId != empId)
                {
                    return Unauthorized(new ErrorModel(401, "You are not authorized to raise a request for another user."));
                }

                Request request = new Request() { RequestMessage = raiseRequestDTO.RequestMessage, RequestStatus = "Opened", RequestRaisedBy = raiseRequestDTO.UserId };
                var result = await _requestService.RaiseRequest(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }


        [Authorize(Policy = "User")]
        [Route("GetRequest")]
        [HttpGet]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Request>>> GetRequestByUser(int userId)
        {
            try
            {
                int empId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "empId")?.Value);

                if (userId != empId)
                {
                    return Unauthorized(new ErrorModel(401, "You are not authorized to access requests for another user."));
                }
                var request = await _requestService.GetRequestsByUserId(userId);
                return Ok(request);
            }
            catch (NoSuchEmployeeException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }


        [Authorize(Policy = "Admin")]
        [Route("GetAllRequest")]
        [HttpGet]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Request>>> GetRequestByAdmin(int userId)
        {
            try
            {
                var request = await _requestService.GetRequestsByAdmin(userId);
                return Ok(request);
            }
            catch (NoSuchEmployeeException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
    }
}
