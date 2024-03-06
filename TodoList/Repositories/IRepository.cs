using System.Linq.Expressions;

namespace TodoList.Repositories
{
    public interface IRepository<TEntity>
    {
        bool Add(TEntity T);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        bool Update(TEntity T);
        bool Delete(int id);
    }
}
