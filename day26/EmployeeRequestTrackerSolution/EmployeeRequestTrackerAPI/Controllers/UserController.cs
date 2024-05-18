using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> Register(EmployeeRegistrationDTO registrationDTO)
        {
            try
            {
                // Map the EmployeeRegistrationDTO to an EmployeeUserDTO
                EmployeeUserDTO userDTO = MapEmployeeRegistrationDTOToEmployeeUserDTO(registrationDTO);

                // Call the registration method with the EmployeeUserDTO
                Employee result = await _userService.Register(userDTO);

                // Return the result
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }

        private EmployeeUserDTO MapEmployeeRegistrationDTOToEmployeeUserDTO(EmployeeRegistrationDTO registrationDTO)
        {
            return new EmployeeUserDTO
            {
                Name = registrationDTO.Name,
                DateOfBirth = registrationDTO.DateOfBirth,
                Phone = registrationDTO.Phone,
                Image = registrationDTO.Image,
                Role = registrationDTO.Role,
                Password = registrationDTO.Password
            };
        }


        [Authorize(Policy = "Admin")]
        [HttpPut("Activate")]
        [ProducesResponseType(typeof(ActivateReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Activate(ActivateDTO activateDTO)
        {
            try
            {
                var result = await _userService.Activate(activateDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
    }
}
