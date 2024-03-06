using System.ComponentModel.DataAnnotations;

namespace CaisseEnregistreuse.NET.Models
{
    public class TypeDeCarte
    {
        [Key]
        public int TypeDeCarteId { get; set; }

        [Display(Name = "Nom du type")]
        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
        public string Nom { get; set; }

        public List<Carte> ListeCartes { get; set; } = new List<Carte>();
    }
}
