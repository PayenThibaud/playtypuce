using System.Linq.Expressions;

namespace CaisseEnregistreuse.NET.Repositories
{

    public interface IRepository<TEntity>
    {
        bool Add(TEntity t);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        bool Update(TEntity t);
        bool Delete(int id);
    }
}
