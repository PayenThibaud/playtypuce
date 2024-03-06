using System.Linq.Expressions;
using TodoList.Models;
using TodoList.NET.Data;

namespace TodoList.Repositories
{
    public class TodoListRepository : IRepository<TodoListClass>
    {
        private ApplicationDbContext _dbContext;
        public TodoListRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CREATE
        public bool Add(TodoListClass todoListClass)
        {
            var addedObj = _dbContext.todoListClasses.Add(todoListClass);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        // READ
        public TodoListClass? GetById(int id)
        {
            return _dbContext.todoListClasses.Find(id);
        }
        public TodoListClass? Get(Expression<Func<TodoListClass, bool>> predicate)
        {
            return _dbContext.todoListClasses.FirstOrDefault(predicate);
        }
        public List<TodoListClass> GetAll()
        {
            return _dbContext.todoListClasses.ToList();
        }
        public List<TodoListClass> GetAll(Expression<Func<TodoListClass, bool>> predicate)
        {
            return _dbContext.todoListClasses.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(TodoListClass todoListClass)
        {
            var todoListClassFromDb = GetById(todoListClass.Id);

            if (todoListClassFromDb == null)
                return false;

            if (todoListClassFromDb.Description != todoListClass.Description)
                todoListClassFromDb.Description = todoListClass.Description;
            if (todoListClassFromDb.Titre != todoListClass.Titre)
                todoListClassFromDb.Titre = todoListClass.Titre;
            if (todoListClassFromDb.StatutEnCours != todoListClass.StatutEnCours)
                todoListClassFromDb.StatutEnCours = todoListClass.StatutEnCours;

            return _dbContext.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int id)
        {
            var todoListClass = GetById(id);
            if (todoListClass == null)
                return false;
            _dbContext.todoListClasses.Remove(todoListClass);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
