using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class TeacherSubject
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

}
