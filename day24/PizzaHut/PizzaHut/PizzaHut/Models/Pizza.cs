using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace PizzaHut.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableStock { get; set; }
    }
}
