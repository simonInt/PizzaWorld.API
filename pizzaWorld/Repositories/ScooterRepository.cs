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
    public class ScooterRepository : IScooterRepository
    {
        public readonly PizzaWorldContext _context;
        public ScooterRepository(PizzaWorldContext context)
        {
            _context = context;
        }
        public async Task<List<Scooter>> GetScooter()
        {
            return await _context.Scooter.ToListAsync();
        }
        public async Task<Scooter> GetScooterById(int id)
        {
            return await _context.Scooter.Where(t => t.ScooterId == id).FirstOrDefaultAsync();
        }
        public async Task CreateScooter(Scooter scooter)
        {
            _context.Scooter.Add(scooter);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteScooter(int id)
        {
            Scooter scooter = await GetScooterById(id);
            _context.Scooter.Remove(scooter);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateScooter(Scooter scooter)
        {
            await _context.SaveChangesAsync();
        }
    }
}
