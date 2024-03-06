using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoListClass
    {
        public int Id { get; set; }

        [Display(Name = "Titre de la tâche")]
        public string Titre { get; set; }

        [Display(Name = "Description de la tâche")]
        public string Description { get; set; }

        [Display(Name = "Statut en cours")]
        public Statut StatutEnCours { get; set; }
    }

    public enum Statut
    {
        Terminée,
        EnCours
    }
}
