using CaisseEnregistreuse.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace CaisseEnregistreuse.NET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Carte> Cartes { get; set; }
        public DbSet<TypeDeCarte> TypeDeCartes { get; set; }

    }
}