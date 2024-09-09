using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class SubjectLanguage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Language { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
