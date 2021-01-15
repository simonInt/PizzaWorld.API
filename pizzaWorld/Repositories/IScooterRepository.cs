using pizzaWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Repositories
{
    public interface IScooterRepository
    {
        Task<List<Scooter>> GetScooter();
        Task<Scooter> GetScooterById(int id);
        Task CreateScooter(Scooter scooter);
        Task DeleteScooter(int id);
        Task UpdateScooter(Scooter scooter);
    }
}
