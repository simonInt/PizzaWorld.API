using pizzaWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Repositories
{
    public interface IPizzaRepository
    {
        Task<List<Pizza>> GetPizza();
        Task<Pizza> GetPizzaById(int id);
        Task CreatePizza(Pizza pizza);
        Task DeletePizza(Pizza pizza);
        Task UpdatePizza(Pizza pizza);
    }
}
