using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PizzaHut.Interfaces;
using PizzaHut.Models;

namespace PizzaHut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Pizza>>> Get()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int loggedInUserId))
            {
                var pizzas = await _pizzaService.GetPizzas();
                return Ok(pizzas.ToList());
            }
            else
            {
                return Unauthorized(new ErrorModel(401, "Invalid JWT token."));
            }
        }
    }
}
