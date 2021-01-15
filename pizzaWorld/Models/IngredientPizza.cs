using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Models
{
    public class IngredientPizza
    {
        public int IngredientPizzaId { get; set; }
        public int IdPizza { get; set; }
        [ForeignKey("IdPizza")]
        public Pizza Pizza { get; set; }
        public int IdIngredient { get; set; }
        [ForeignKey("IdIngredient")]
        public Ingredient Ingredient { get; set; }
    }
}
