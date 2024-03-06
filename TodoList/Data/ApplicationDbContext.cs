using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.NET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TodoListClass> todoListClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int LastIndex = 0;
            var todoListClasses = new List<TodoListClass>()
            {
                new TodoListClass() {Id=++LastIndex, Titre = "Rangement", Description = "Préparer la venue de belle-maman", StatutEnCours = Statut.EnCours},
                new TodoListClass() { Id=++LastIndex, Titre = "Promenade", Description = "Promener Médor et faire attention au chien de la voisine", StatutEnCours = Statut.Terminée}
            };

            modelBuilder.Entity<TodoListClass>().HasData(todoListClasses);
        }
    }
}
