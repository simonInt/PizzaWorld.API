using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int TempPrepa { get; set; }
        public string ImgPath { get; set; }
    }
}
