using PizzaHut.Models;

namespace PizzaHut.Interfaces
{
    public interface IPizzaService
    {
        public Task<IEnumerable<Pizza>> GetPizzas();
       
    }

}