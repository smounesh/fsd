using PizzaHut.Models;

namespace PizzaHut.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> OrderPizza(int PizzaId, int userId, int quantity);

        public Task<IEnumerable<Order>> GetOrderforId(int userId);
    }
}
