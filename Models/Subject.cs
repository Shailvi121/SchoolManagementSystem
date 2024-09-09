using SchoolManagementSystem.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Subject
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Class { get; set; }
    public List<SubjectLanguage> SubjectLanguages { get; set; }
    public ICollection<TeacherSubject> TeacherSubjects { get; set; }

}
