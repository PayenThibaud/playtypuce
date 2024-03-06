using CaisseEnregistreuse.NET.Data;
using CaisseEnregistreuse.NET.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CaisseEnregistreuse.NET.Repositories
{
    public class CarteRepository : IRepository<Carte>
    {
        private ApplicationDbContext _dbContext;
        public CarteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public bool Add(Carte carte)
        {
            var addedObj = _dbContext.Cartes.Add(carte);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        // READ
        public Carte? GetById(int id)
        {
            return _dbContext.Cartes.Find(id);
        }
        public Carte? Get(Expression<Func<Carte, bool>> predicate)
        {
            return _dbContext.Cartes.FirstOrDefault(predicate);
        }
        public List<Carte> GetAll()
        {
            return _dbContext.Cartes.ToList();
        }
        public List<Carte> GetAll(Expression<Func<Carte, bool>> predicate)
        {
            return _dbContext.Cartes.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(Carte carte)
        {
            var carteFromDb = GetById(carte.Id);

            if (carteFromDb == null)
                return false;

            if (carteFromDb.Nom != carte.Nom)
                carteFromDb.Nom = carte.Nom;

            if (carteFromDb.Description != carte.Description)
                carteFromDb.Description = carte.Description;

            if (carteFromDb.Prix != carte.Prix)
                carteFromDb.Prix = carte.Prix;

            if (carteFromDb.QuantiteEnStock != carte.QuantiteEnStock)
                carteFromDb.QuantiteEnStock = carte.QuantiteEnStock;

            if (carteFromDb.TypeDeCarteId != carte.TypeDeCarteId)
                carteFromDb.TypeDeCarteId = carte.TypeDeCarteId;

            if (carteFromDb.ImageCarte != carte.ImageCarte)
                carteFromDb.ImageCarte = carte.ImageCarte;

            return _dbContext.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int id)
        {
            var carte = GetById(id);
            if (carte == null)
                return false;
            _dbContext.Cartes.Remove(carte);
            return _dbContext.SaveChanges() > 0;
        }
    }
}