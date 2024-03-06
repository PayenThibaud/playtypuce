using Playtypuces.Data;
using Playtypuces.Models;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace Playtypuces.Repositories
{
    internal class PlaytypuceRepository : IRepository<Playtypuce, int>
    {
        public void Delete(Playtypuce entity)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            context.Playtypuces.Remove(entity);
            context.SaveChanges();
        }

        public List<Playtypuce> GetAll()
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            return context.Playtypuces.ToList();
        }

        public Playtypuce? GetOneById(int id)
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            return context.Playtypuces.Find(id);
        }

        public List<Playtypuce> GetOneBySpecification(Expression<Func<Playtypuce, bool>> predicate)
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            return context.Playtypuces.Where(predicate).ToList();
        }

        public void Save(Playtypuce entity)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            context.Playtypuces.Add(entity);
            context.SaveChanges();
        }

        public void Update(Playtypuce entity)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            context.Playtypuces.Update(entity);
            context.SaveChanges();
        }
    }
}

