using PizzaHut.Models;

namespace PizzaHut.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> OrderPizza(int PizzaId, int UserId, int quantity);

        public Task<IEnumerable<Order>> GetMyOrders(int UserId);
    }
}
