using PizzaHut.Interfaces;
using PizzaHut.Models;
using PizzaHut.Models.DTO;
using PizzaHut.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace PizzaHut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Employee>> Login(UserLoginDTO userLoginDTO)
        {
            _logger.LogInformation("Login attempt for user: {Username}", userLoginDTO);
            try
            {
                var result = await _userService.Login(userLoginDTO);
                _logger.LogInformation("User {Username} logged in successfully", userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Login failed for user: {Username}", userLoginDTO);
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> Register(EmployeeUserDTO userDTO)
        {
            _logger.LogInformation("Register attempt for user: {Username}", userDTO);
            try
            {
                Employee result = await _userService.Register(userDTO);
                _logger.LogInformation("User {Username} registered successfully", userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration failed for user: {Username}", userDTO);
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
    }
}
