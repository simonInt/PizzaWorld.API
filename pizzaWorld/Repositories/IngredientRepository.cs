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
    public class IngredientRepository : IIngredientRepository
    {
        public readonly PizzaWorldContext _context;
        public IngredientRepository(PizzaWorldContext context)
        {
            _context = context;
        }
        public async Task<List<Ingredient>> GetIngredient()
        {
            return await _context.Ingredient.ToListAsync();
        }
        public async Task<Ingredient> GetIngredientById(int id)
        {
            return await _context.Ingredient.Where(t => t.IngredientId == id).FirstOrDefaultAsync();
        }
        public async Task CreateIngredient(Ingredient ingredient)
        {
            _context.Ingredient.Add(ingredient);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteIngredient(int id)
        {
            Ingredient ingredient = await GetIngredientById(id);
            _context.Ingredient.Remove(ingredient);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateIngredient(Ingredient ingredient)
        {
            await _context.SaveChangesAsync();
        }
    }
}
