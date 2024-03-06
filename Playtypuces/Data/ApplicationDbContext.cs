using Microsoft.EntityFrameworkCore;
using Playtypuces.Models;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Playtypuces.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Playtypuce> Playtypuces { get; set; }

        public ApplicationDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:m2idotnet.database.windows.net,1433;Initial Catalog=ThibaudDBB;Persist Security Info=False;User ID=m2iadmin;Password=p@ssword1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }
}
