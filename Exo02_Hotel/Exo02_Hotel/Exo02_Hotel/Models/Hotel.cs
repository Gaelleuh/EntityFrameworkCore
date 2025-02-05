using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo02_Hotel.Models
{
    internal class Hotel
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Adresse { get; set; } = null!;
        public List<Client> Clients { get; set; } = [];
        public List<Chambre> Chambres { get; set; } = [];
        public List<Reservation> Reservations { get; set; } = [];
    }
}
