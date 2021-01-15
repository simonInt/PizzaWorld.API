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
    public class LivreurRepository : ILivreurRepository
    {
        public readonly PizzaWorldContext _context;
        public LivreurRepository(PizzaWorldContext context)
        {
            _context = context;
        }
        public async Task<List<Livreur>> GetLivreur()
        {
            return await _context.Livreur.ToListAsync();
        }
        public async Task<Livreur> GetLivreurById(int id)
        {
            return await _context.Livreur.Where(t => t.LivreurId == id).FirstOrDefaultAsync();
        }
        public async Task CreateLivreur(Livreur livreur)
        {
            _context.Livreur.Add(livreur);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteLivreur(int id)
        {
            Livreur livreur = await GetLivreurById(id);
            _context.Livreur.Remove(livreur);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateLivreur(Livreur livreur)
        {
            await _context.SaveChangesAsync();
        }
    }
}
