using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaHut.Exceptions;
using PizzaHut.Interfaces;
using PizzaHut.Models;

namespace PizzaHut.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IReposiroty<int, Pizza> _repository;

        public PizzaService(IReposiroty<int, Pizza> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            var pizzas = await _repository.Get();
            if (pizzas.Count() == 0)
                throw new NoPizzaFoundException();
            return pizzas.Where(p => p.AvailableStock > 0);
        }
    }
}

