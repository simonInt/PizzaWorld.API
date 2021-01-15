using pizzaWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Repositories
{
    public interface ILivreurRepository
    {
        Task<List<Livreur>> GetLivreur();
        Task<Livreur> GetLivreurById(int id);
        Task CreateLivreur(Livreur livreur);
        Task DeleteLivreur(int id);
        Task UpdateLivreur(Livreur livreur);
    }
}
