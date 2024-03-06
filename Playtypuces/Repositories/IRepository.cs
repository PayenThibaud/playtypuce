using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Playtypuces.Repositories
{
    public interface IRepository<T, Tid> where T : new()
    {
        void Save(T entity);
        List<T> GetAll();

        List<T> GetOneBySpecification(Expression<Func<T, bool>> predicate);
        T? GetOneById(Tid id);
        void Update(T entity);
        void Delete(T entity);
    }
}
