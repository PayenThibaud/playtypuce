using System.ComponentModel.DataAnnotations;

namespace Playtypuces.Models
{
    public class Playtypuce
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Couleur")]
        public string Colour { get; set; }

        [Display(Name = "Sexe")]
        public string Gender { get; set; }
    }
}
