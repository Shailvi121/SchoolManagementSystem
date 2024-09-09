using SchoolManagementSystem.Models;
using SchoolManagementSystem.Service;
using SchoolManagementSystem.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Interface
{
    public interface ITeacherService : IService<Teacher>
    {
        Task<List<TeacherViewModel>> GetAllTeachersAsync();
        Task<TeacherViewModel> GetTeacherByIdAsync(int id);
        Task AddTeacherAsync(TeacherViewModel model, IFormFile imageFile);
        
    }
}
