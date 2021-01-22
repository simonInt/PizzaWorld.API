using pizzaWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Repositories
{
    public interface IAdresseRepository
    {
        Task<List<Adresse>> GetAdresse();
        Task<Adresse> GetAdresseById(int id);
        Task CreateAdresse(Adresse adresse);
        Task DeleteAdresse(int id);
        Task UpdateAdresse(Adresse adresse);
    }
}
