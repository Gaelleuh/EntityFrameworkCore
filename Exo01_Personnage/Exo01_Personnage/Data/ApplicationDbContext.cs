
using Exo01_Personnage.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo01_Personnage.Data;
internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base()
    {

    }

    public DbSet<Personnage> Personnages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\EFCorePersonnage;Integrated Security=True");
    }
}
