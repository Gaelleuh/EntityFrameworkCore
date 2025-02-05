using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exo02_Hotel.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Exo02_Hotel.Data;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base()
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Chambre> Chambres { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Hotel> Hotels { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\EFCoreHotel;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // DATA SEED => données de base de l'application
        modelBuilder.Entity<Chambre>().HasData(
            new Chambre() { NumeroChambre = 101, StatutChambre = Models.Enums.StatutChambre.Libre, NombreLits = 2, Tarif = 100 },
            new Chambre() { NumeroChambre = 102, StatutChambre = Models.Enums.StatutChambre.Occupe, NombreLits = 3, Tarif = 150 },
            new Chambre() { NumeroChambre = 103, StatutChambre = Models.Enums.StatutChambre.Libre, NombreLits = 2, Tarif = 100 },
            new Chambre() { NumeroChambre = 201, StatutChambre = Models.Enums.StatutChambre.EnNettoyage, NombreLits = 4, Tarif = 200 },
            new Chambre() { NumeroChambre = 202, StatutChambre = Models.Enums.StatutChambre.Libre, NombreLits = 2, Tarif = 100 },
            new Chambre() { NumeroChambre = 203, StatutChambre = Models.Enums.StatutChambre.Occupe, NombreLits = 3, Tarif = 150 }
            );
    }
}


