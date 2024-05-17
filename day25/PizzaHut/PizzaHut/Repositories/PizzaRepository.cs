using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaHut.Contexts;
using PizzaHut.Exceptions;
using PizzaHut.Interfaces;
using PizzaHut.Models;

namespace PizzaHut.Repositories
{
    public class PizzaRepository : IReposiroty<int, Pizza>
    {
        private readonly PizzaHutContext _context;

        public PizzaRepository(PizzaHutContext context)
        {
            _context = context;
        }

        public async Task<Pizza> Add(Pizza item)
        {
            _context.Pizzas.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                await _context.SaveChangesAsync();
                return pizza;
            }
            throw new NoSuchPizzaException();
        }

        public async Task<Pizza> Get(int key)
        {
            return await _context.Pizzas.FirstOrDefaultAsync(p => p.PizzaId == key);
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza> Update(Pizza item)
        {
            var pizza = await Get(item.PizzaId);
            if (pizza != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return item;
            }
            throw new NoSuchPizzaException();
        }

        public async Task<int> GetAvailableQuantity(int pizzaId)
        {
            var pizza = await _context.Pizzas.FindAsync(pizzaId);
            return pizza?.AvailableStock ?? 0;
        }
    }
}