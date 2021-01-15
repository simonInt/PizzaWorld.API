using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string nom { get; set; }
    }
}
