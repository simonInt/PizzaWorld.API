using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Models
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        public int Numero { get; set; }
        public int Rue { get; set; }
        public int Ville { get; set; }
        public int CodePostal { get; set; }
    }
}
