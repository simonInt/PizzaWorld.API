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
    public class ClientRepository : IClientRepository
    {
        public readonly PizzaWorldContext _context;
        public ClientRepository(PizzaWorldContext context)
        {
            _context = context;
        }
        public async Task<List<Client>> GetClient()
        {
            return await _context.Client.ToListAsync();
        }
        public async Task<Client> GetClientById(int id)
        {
            return await _context.Client.Where(t => t.ClientId == id).FirstOrDefaultAsync();
        }
        public async Task CreateClient(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteClient(int id)
        {
            Client client = await GetClientById(id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateClient(Client client)
        {
            await _context.SaveChangesAsync();
        }
    }
}
