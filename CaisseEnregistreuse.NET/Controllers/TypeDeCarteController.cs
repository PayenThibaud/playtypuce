using CaisseEnregistreuse.NET.Models;
using CaisseEnregistreuse.NET.Repositories;
using CaisseEnregistreuse.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaisseEnregistreuse.NET.Controllers
{
    public class TypeDeCarteController : Controller
    {
        private readonly IRepository<TypeDeCarte> _typeDeCarteRepository;

        public TypeDeCarteController(

            IRepository<TypeDeCarte> typeDeCarteRepository
            )
        {

            _typeDeCarteRepository = typeDeCarteRepository;
        }

        public IActionResult Index()
        {
            return View(_typeDeCarteRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_typeDeCarteRepository.GetById(id));
        }

        public IActionResult Form(int id)
        {
            if (id == 0)
                return View();

            var typeDeCarte = _typeDeCarteRepository.GetById(id);

            return View(typeDeCarte);
        }

        public IActionResult SubmitTypeDeCarte(TypeDeCarte typeDeCarte)
        {
            if (typeDeCarte.TypeDeCarteId == 0)
            {
                // Nouveau type de carte, ajoutez-le
                _typeDeCarteRepository.Add(typeDeCarte);
            }
            else
            {
                // Type de carte existant, mettez à jour
                _typeDeCarteRepository.Update(typeDeCarte);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {


            _typeDeCarteRepository.Delete(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
