using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizzaWorld.Models;
using pizzaWorld.PizzaWorldDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        public readonly PizzaWorldContext _context;
        public PizzaRepository(PizzaWorldContext context)
        {
            _context = context;
        }
        public async Task<List<Pizza>> GetPizza()
        {
            return await _context.Pizza.ToListAsync();
        }
        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _context.Pizza.Where(t => t.PizzaId == id).FirstOrDefaultAsync();
        }
        public async Task CreatePizza(Pizza pizza)
        {
            _context.Pizza.Add(pizza);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePizza(Pizza pizza)
        {
            _context.Pizza.Remove(pizza);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePizza(Pizza pizza)
        {
            await _context.SaveChangesAsync();
        }
    }
}
