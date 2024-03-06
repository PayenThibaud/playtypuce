using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Controllers
{
    public class TodoListController : Controller
    {
        private readonly IRepository<TodoListClass> _todoListClassRepository;

        public TodoListController(IRepository<TodoListClass> todoListClassRepository)
        {
            _todoListClassRepository = todoListClassRepository;
        }

        public IActionResult Index()
        {
            return View(_todoListClassRepository.GetAll());
        }

        public IActionResult Details(int Id)
        {
            return View(_todoListClassRepository.GetById(Id));
        }

        public IActionResult Form(int Id)
        {
            if (Id == 0)
            {
                return View();
            }
            var todoListClass = _todoListClassRepository.GetById(Id);
            return View(todoListClass);
        }

        public IActionResult SubmitTodoListClass(TodoListClass todoListClass)
        {
            if (todoListClass.Id == 0)
            {
                _todoListClassRepository.Add(todoListClass);
            }
            else
            {
                _todoListClassRepository.Update(todoListClass);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            _todoListClassRepository.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateStatus(int id, string status)
        {
            var todoListClass = _todoListClassRepository.GetById(id);

            if (todoListClass == null)
            {
                return NotFound();
            }

            todoListClass.StatutEnCours = status == "EnCours" ? Statut.EnCours : Statut.Terminée;

            _todoListClassRepository.Update(todoListClass);

            return RedirectToAction(nameof(Index));
        }

    }
}
