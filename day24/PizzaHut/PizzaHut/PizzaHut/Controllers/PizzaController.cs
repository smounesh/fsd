using PizzaHut.Interfaces;
using PizzaHut.Models;
using Microsoft.AspNetCore.Mvc;
using PizzaHut.Exceptions;

namespace PizzaHut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var pizzas = await _pizzaService.GetPizzas();
            return Ok(pizzas.ToList());
        }
    }
}