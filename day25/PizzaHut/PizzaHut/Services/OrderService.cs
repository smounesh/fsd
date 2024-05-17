using PizzaHut.Exceptions;
using PizzaHut.Interfaces;
using PizzaHut.Models;
using PizzaHut.Repositories;

namespace PizzaHut.Services
{
    public class OrderService : IOrderService
    {
        private readonly IReposiroty<int, Order> _orderRepository;
        private readonly IReposiroty<int, Pizza> _pizzaRepository;


        public OrderService(IReposiroty<int, Order> orderRepository, IReposiroty<int, Pizza> pizzaRepository)
        {
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
        }

        public async Task<Order> OrderPizza(int pizzaId, int userId, int quantity)
        {
            var pizza = await _pizzaRepository.Get(pizzaId);
            if (pizza == null)
            {
                throw new NoSuchPizzaException();
            }

            if (pizza.AvailableStock < quantity)
            {
                throw new InsufficientStockException();
            }

            // Deduct the quantity from available stock
            pizza.AvailableStock -= quantity;
            await _pizzaRepository.Update(pizza);

            var order = new Order
            {
                PizzaId = pizzaId,
                UserId = userId,
                Quantity = quantity
            };

            return await _orderRepository.Add(order);
        }

        public async Task<IEnumerable<Order>> GetMyOrders(int userId)
        {
            var allOrders = await _orderRepository.Get();
            return allOrders.Where(o => o.UserId == userId);
        }

    }
}