using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string RollNumber { get; set; }
        public string? Class { get; set; }
        public string Image { get; set; }

    }
}

