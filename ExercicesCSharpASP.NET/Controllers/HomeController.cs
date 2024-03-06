using ExercicesCSharpASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExercicesCSharpASP.NET.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        // /Home/Index
        public IActionResult Index()
        {
            List<string> chaines = new()
            {
                "chaine1",
                "chaine2",
                "chaine3",
                "blabla",
            };

            // passer des données à la vue

            // méthode 1: ViewData
            ViewData["chaines"] = chaines;

            ViewData["message"] = "message depuis Index";

            // méthode 2: ViewBag
            ViewBag.Chaines = chaines;

            // méthode 3: Model
            return View(chaines);


            //return View();
            //return View("Index");
        }
        public IActionResult Index2()
        {
            ViewData["message"] = "message depuis Index 2, ce n'est pas la même action !";

            return View("Index"); // => on retourne directement la vue Index.cshtml
        }
        public IActionResult Index3()
        {
            return RedirectToAction("Index"); // => repasse par l'action/la méthode Index de HomeController
            //return RedirectToAction(nameof(Index));
        }

        // /Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // /Home/DitBonjour
        public string DitBonjour()
        {
            return "Bonjour à toi !";
        }

        // /Home/DitBonjourA?personne=Guillaume
        public string DitBonjourA(string personne)
        {
            return $"Bonjour à toi {personne}!";
        }

        // /Home/Compter?id=15
        // /Home/Compter/15
        public string Compter(int id)
        {
            string chaine = "";
            for (int i = 0; i < id; i++)
            {
                chaine += i + ", ";
            }
            return $"Compte : {chaine}!";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


