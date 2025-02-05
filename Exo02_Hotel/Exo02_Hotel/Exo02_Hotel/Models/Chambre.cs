using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo02_Hotel.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Exo02_Hotel.Models
{
    internal class Chambre
    {
        [Key] 
        public int NumeroChambre { get; set; }
        public StatutChambre StatutChambre { get; set; }
        public int NombreLits { get; set; }
        [Precision(20,2)]
        public decimal Tarif { get; set; } 
    }
}
