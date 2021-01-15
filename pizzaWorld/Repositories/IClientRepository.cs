using pizzaWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClient();
        Task<Client> GetClientById(int id);
        Task CreateClient(Client client);
        Task DeleteClient(int id);
        Task UpdateClient(Client client);
    }
}
