using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaHut.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}
