using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

public class Teacher
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public int? Age { get; set; }
    [Required]
    public string? Sex { get; set; }
    public string Image { get; set; }
    public ICollection<TeacherSubject> TeacherSubjects { get; set; }

}
