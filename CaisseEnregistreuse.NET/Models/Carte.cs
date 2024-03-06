using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaisseEnregistreuse.NET.Models
{
    public class Carte
    {
        public int Id { get; set; }


        [Display(Name = "Nom de la carte")]
        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
        public string Nom { get; set; }

        [Display(Name = "Description de la carte")]
        [Required(ErrorMessage = "La description est requis.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "La description doit être compris entre 0 et 120")]
        public string Description { get; set; }

        [Display(Name = "Prix de la carte")]
        [Required(ErrorMessage = "Le prix est requis.")]
        [Precision(18,2)]
        public decimal Prix { get; set; }

        [Display(Name = "Quantité en stock de la carte")]
        [Required(ErrorMessage = "La quantité en stock est requis.")]
        [Range(0, 99999, ErrorMessage = "La quantité doit être compris entre 0 et 99999")]
        public int QuantiteEnStock { get; set; }

        [Display(Name = "Type de carteId")]
        public int TypeDeCarteId { get; set; }

        [Display(Name = "Type de carte")]
        [ForeignKey(nameof(TypeDeCarteId))]
        public TypeDeCarte TypeDeCarte { get; set; }

        [Display(Name = "Image de la carte")]
        public string ImageCarte { get; set; }
    }
}
