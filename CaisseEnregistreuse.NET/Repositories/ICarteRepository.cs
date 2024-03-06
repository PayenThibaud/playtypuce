using CaisseEnregistreuse.NET.Models;
using System.Linq.Expressions;

namespace CaisseEnregistreuse.NET.Repositories
{
    public interface ICarteRepository
    {
        bool Add(Carte carte);
        Carte? Get(Expression<Func<Carte, bool>> predicate);
        List<Carte> GetAll();
        List<Carte> GetAll(Expression<Func<Carte, bool>> predicate);
        Carte? GetById(int id);
        bool Update(Carte carte);
        bool Delete(int id);
    }
}
