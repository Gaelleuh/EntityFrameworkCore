using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo02_Hotel.Models.Enums;

namespace Exo02_Hotel.Models
{
    internal class Reservation
    {
        public int Id { get; set; }
        public StatutReservation StatutReservation { get; set; }
        public List<Chambre> Chambres { get; set; } = [];
        public Client Client { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nom: {StatutReservation}, Chambre(s): {Chambres}, Client: {Client}";
        }
    }
}
