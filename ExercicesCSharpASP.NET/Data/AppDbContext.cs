using ExercicesCSharpASP.NET.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace ExercicesCSharpASP.NET.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
#nullable disable
        public DbSet<Contact> Contacts { get; set; }
#nullable enable
    }
}
