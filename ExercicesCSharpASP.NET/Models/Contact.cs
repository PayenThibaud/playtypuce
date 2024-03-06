using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExercicesCSharpASP.NET.Models
{
    [Table("contact")]
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("firstname")]
        [Required]
        public string? FirstName { get; set; }
        [Column("lastname")]
        [Required]
        public string? LastName { get; set; }
        [Column("birth_date")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Column("gender")]
        [Required]
        [StringLength(1)]
        public string? Gender { get; set; }
    }
}

