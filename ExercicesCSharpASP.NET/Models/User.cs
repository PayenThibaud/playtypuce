using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExercicesCSharpASP.NET.Models
{
    public class User
    {
        [Column("id)")]
        public string Id { get; set; }

        [Column("firsname)")]
        [Required]
        public string FirstName { get; set; }

        [Column("lastname)")]
        [Required]
        public string LastName { get; set; }

        [Required]
        public bool isAdmin { get; set; } = false;

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
