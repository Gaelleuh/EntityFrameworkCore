using System.ComponentModel.DataAnnotations;

namespace Exo01_Personnage.Models
{
    internal class Personnage
    {
        public int Id { get; set; }
        public string? Pseudo { get; set; }
        public int PointsDeVie { get; set; }
        public int Armure { get; set; }
        public int Degats { get; set; }
        public DateTime DateCreation { get; set; }
        public int NombrePersonneTues { get; set; } = 0;


        public override string ToString()
        {
            return $"Id:{Id:D3}, Pseudo:{Pseudo}, pointsDeVie {PointsDeVie}, armure:{Armure}, degats:{Degats},date de création {DateCreation:dd/MM/yyyy}, nombre de personnes tuées: {NombrePersonneTues}";
        }

    }
}
