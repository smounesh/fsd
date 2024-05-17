using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using PizzaHut.Interfaces;
using PizzaHut.Models.DTO;
using PizzaHut.Models;

namespace PizzaHut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)] // Return type changed to string for JWT token
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var employee = await _userService.Login(userLoginDTO);
                if (employee != null)
                {
                    // Generate JWT token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()), // Add user ID claim
                            // Add more claims if needed
                        }),
                        Expires = DateTime.UtcNow.AddDays(1), // Token expiration time
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    // Return JWT token
                    return Ok(tokenString);
                }
                else
                {
                    return Unauthorized(new ErrorModel(401, "Invalid username or password"));
                }
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> Register(EmployeeUserDTO userDTO)
        {
            try
            {
                Employee result = await _userService.Register(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
    }
}
