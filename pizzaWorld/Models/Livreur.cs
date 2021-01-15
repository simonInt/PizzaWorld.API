using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Models
{
    public class Livreur
    {
        public int LivreurId { get; set; }
        public int Nom { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
