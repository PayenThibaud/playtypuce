using CaisseEnregistreuse.NET.Models;
using CaisseEnregistreuse.NET.Repositories;
using CaisseEnregistreuse.NET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaisseEnregistreuse.NET.Controllers
{
    public class CarteController : Controller
    {
        private readonly IRepository<Carte> _carteRepository;
        private readonly IRepository<TypeDeCarte> _typeDeCarteRepository; // Ajout de cette ligne
        private readonly IUploadService _uploadService;

        //Constructeur & injection de dépendances !!
        public CarteController(
            IRepository<Carte> carteRepository,
            IRepository<TypeDeCarte> typeDeCarteRepository,
            IUploadService uploadService
        )
        {
            _carteRepository = carteRepository;
            _typeDeCarteRepository = typeDeCarteRepository;
            _uploadService = uploadService;
        }

        public IActionResult Index()
        {
            // Récupérez la liste des cartes
            var cartes = _carteRepository.GetAll();

            // Préchargez les noms des types de cartes
            var typeDeCarteNoms = _typeDeCarteRepository.GetAll().ToDictionary(t => t.TypeDeCarteId, t => t.Nom);
            ViewBag.TypeDeCarteNoms = typeDeCarteNoms;

            // Passez la liste des cartes à la vue
            return View(cartes);
        }

        public IActionResult Details(int id)
        {
            var carte = _carteRepository.GetById(id);

            // Préchargez le nom du type de carte
            var typeDeCarteNom = _typeDeCarteRepository.GetById(carte.TypeDeCarteId)?.Nom;
            ViewBag.TypeDeCarteNom = typeDeCarteNom;

            return View(carte);
        }

        public IActionResult Form(int id)
        {
            ViewBag.TypeDeCartes = _typeDeCarteRepository.GetAll();

            if (id == 0) 
                return View();

            var carte = _carteRepository.GetById(id);

            return View(carte);
        }

        public IActionResult SubmitCarte(Carte carte, IFormFile picture)
        {
            // Vérifiez si une image a été fournie
            if (picture != null && picture.Length > 0)
            {
                carte.ImageCarte = _uploadService.Upload(picture);
            }
            else
            {
                carte.ImageCarte = "chemin/vers/image_par_defaut.jpg";
            }

            if (carte.Id == 0)
                _carteRepository.Add(carte);
            else
                _carteRepository.Update(carte);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {


            _carteRepository.Delete(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
