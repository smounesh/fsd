using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaHut.Contexts;
using PizzaHut.Exceptions;
using PizzaHut.Interfaces;
using PizzaHut.Models;

namespace PizzaHut.Repositories
{
    public class OrderRepository : IReposiroty<int, Order>
    {
        private readonly PizzaHutContext _context;

        public OrderRepository(PizzaHutContext context)
        {
            _context = context;
        }

        public async Task<Order> Add(Order item)
        {
            _context.Orders.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Order> Delete(int key)
        {
            var order = await Get(key);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return order;
            }
            throw new NoSuchOrderException();
        }

        public async Task<Order> Get(int key)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == key);
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> Update(Order item)
        {
            var order = await Get(item.OrderId);
            if (order != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return item;
            }
            throw new NoSuchOrderException();
        }
    }
}