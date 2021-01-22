using pizzaWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Repositories
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetIngredient();
        Task<Ingredient> GetIngredientById(int id);
        Task CreateIngredient(Ingredient ingredient);
        Task DeleteIngredient(int id);
        Task UpdateIngredient(Ingredient ingredient);
    }
}
