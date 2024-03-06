using CaisseEnregistreuse.NET.Models;
using System.Linq.Expressions;

namespace CaisseEnregistreuse.NET.Repositories
{
    public interface ITypeDeCarte
    {
        bool Add(TypeDeCarte typeDeCarte);
        TypeDeCarte? Get(Expression<Func<Carte, bool>> predicate);
        List<TypeDeCarte> GetAll();
        List<TypeDeCarte> GetAll(Expression<Func<TypeDeCarte, bool>> predicate);
        Carte? GetById(int id);
        bool Update(TypeDeCarte typeDeCarte);
        bool Delete(int id);
    }
}

