using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo01Bases_EFCore.Data;
internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext():base()
    {

    }

    public DbSet<Livre> Livres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source = (localdb)\EFCore; Integrated Security = True");
    }
}

