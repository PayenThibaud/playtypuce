namespace CaisseEnregistreuse.NET.Services
{
    public class UploadService : IUploadService
    {
        private readonly IWebHostEnvironment _environment;

        public UploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public string Upload(IFormFile file)
        {
            string guid = Guid.NewGuid().ToString();// identifiant unique => c'est une chaine de caractères très longue composée de lettres, chiffres et -
            string nomFichier = guid + "-" + file.FileName; // ici il sera donc impossible d'avoir 2 fois le même nom de fichier => évite les conflits en cas de doublon
            string pathToFile = Path.Combine(_environment.WebRootPath, "images", nomFichier); // chemin du fichier  sur le serveur (on récupère C:/User/....../images/nomFichier)

            FileStream stream = File.Create(pathToFile);// on crée le fichier, il est vide
            file.CopyTo(stream);// on copie le contenu dans le nouveau fichier
            stream.Close(); // on ferme le fichier

            return "/images/" + nomFichier; // on retourne le chemin du fichier sur le navigateur (le dossier wwwroot correspond à la racine)
        }
    }
}
