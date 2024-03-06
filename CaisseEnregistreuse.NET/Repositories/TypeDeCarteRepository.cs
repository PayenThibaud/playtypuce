using CaisseEnregistreuse.NET.Data;
using CaisseEnregistreuse.NET.Models;
using System.Linq.Expressions;

namespace CaisseEnregistreuse.NET.Repositories
{
    public class TypeDeCarteRepository : IRepository<TypeDeCarte>
    {
        private ApplicationDbContext _dbContext;
        public TypeDeCarteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public bool Add(TypeDeCarte typeDeCarte)
        {
            var addedObj = _dbContext.TypeDeCartes.Add(typeDeCarte);
            _dbContext.SaveChanges();
            return addedObj.Entity.TypeDeCarteId > 0;
        }

        // READ
        public TypeDeCarte? GetById(int id)
        {
            return _dbContext.TypeDeCartes.Find(id);
        }
        public TypeDeCarte? Get(Expression<Func<TypeDeCarte, bool>> predicate)
        {
            return _dbContext.TypeDeCartes.FirstOrDefault(predicate);
        }
        public List<TypeDeCarte> GetAll()
        {
            return _dbContext.TypeDeCartes.ToList();
        }
        public List<TypeDeCarte> GetAll(Expression<Func<TypeDeCarte, bool>> predicate)
        {
            return _dbContext.TypeDeCartes.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(TypeDeCarte typeDeCarte)
        {
            var typeDeCarteFromDb = GetById(typeDeCarte.TypeDeCarteId);

            if (typeDeCarteFromDb.Nom != typeDeCarte.Nom)
                typeDeCarteFromDb.Nom = typeDeCarte.Nom;

            return _dbContext.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int id)
        {
            var typeDeCarte = GetById(id);
            if (typeDeCarte == null)
                return false;
            _dbContext.TypeDeCartes.Remove(typeDeCarte);
            return _dbContext.SaveChanges() > 0;
        }
    }
}