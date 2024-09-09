using SchoolManagementSystem.Models;
using SchoolManagementSystem.Service;
using SchoolManagementSystem.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Interface
{
    public interface IStudentService : IService<Student>
    {
        Task<List<StudentViewModel>> GetStudentsByClassAsync(string className);
        Task<List<StudentViewModel>> SearchStudentsByNameAsync(string name);
        Task<StudentViewModel> GetStudentByIdAsync(int id);
        Task AddStudentAsync(StudentViewModel model,IFormFile imageFile);
    }
}
