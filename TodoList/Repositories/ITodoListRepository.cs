using System.Linq.Expressions;
using TodoList.Models;

namespace TodoList.Repositories
{
    public interface ITodoListRepository
    {
        bool Add(TodoListClass todoListClass);
        TodoListClass? Get(Expression<Func<TodoListClass, bool>> predicate);
        List<TodoListClass> GetAll();
        List<TodoListClass> GetAll(Expression<Func<TodoListClass, bool>> predicate);
        TodoListClass? GetById(int id);
        bool Update(TodoListClass todoListClass);
        bool Delete(int id);
    }
}
