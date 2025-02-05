using Demo01Bases_EFCore.Data;
using Microsoft.EntityFrameworkCore;

using var context = new ApplicationDbContext();

var fleursDuMal = new Livre()
{
    Titre = "Les fleurs du mal",
    Auteur = "Charles Baudelaire",
    DatePublication = new DateTime(1857, 06, 21),
    Description = "Un livre qu'il est rempli de poèmes"
};

var tchoupi = new Livre()
{
    Titre = "Tchoupi à l'école",
    Auteur = "Auteur pour enfants",
    DatePublication = new DateTime(1950, 12, 21),
    Description = "Passionnante histoire de Tchoupi, drame comique et sinique..."
};

context.Livres.Add(fleursDuMal);
context.Livres.Add(tchoupi);

context.SaveChanges();