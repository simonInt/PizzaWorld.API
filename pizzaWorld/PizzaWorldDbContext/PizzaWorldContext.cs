using Microsoft.EntityFrameworkCore;
using pizzaWorld.Models;


namespace pizzaWorld.PizzaWorldDbContext
{
    public class PizzaWorldContext : DbContext
    {
        public PizzaWorldContext(DbContextOptions<PizzaWorldContext> options) : base(options)
        {

        }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Livreur> Livreur { get; set; }
        public DbSet<Scooter> Scooter { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<IngredientPizza> IngredientPizza { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Adresse> Adresse { get; set; }
    }
}
