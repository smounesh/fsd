using PizzaHut.Interfaces;
using PizzaHut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;

namespace PizzaHut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> OrderPizza(int pizzaId, int quantity)
        {
            try
            {
                // Retrieve user ID from JWT token
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int loggedInUserId))
                {
                    // Proceed with ordering
                    var order = await _orderService.OrderPizza(pizzaId, loggedInUserId, quantity);
                    return Ok(order);
                }
                else
                {
                    return Unauthorized(new ErrorModel(401, "Invalid JWT token."));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetMyOrders()
        {
            try
            {
                // Retrieve user ID from JWT token
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int loggedInUserId))
                {
                    // Proceed with retrieving orders
                    var orders = await _orderService.GetMyOrders(loggedInUserId);
                    return Ok(orders);
                }
                else
                {
                    return Unauthorized(new ErrorModel(401, "Invalid JWT token."));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
