using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using SchoolManagementSystem.Interface;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModel;

namespace SchoolManagementSystem.Service
{
    public class StudentService : Service<Student>, IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public StudentService(IRepository<Student> repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<StudentViewModel>> GetStudentsByClassAsync(string className)
        {
            var students = await _repository.GetAllAsync();
            var filteredStudents = students.Where(s => s.Class == className).ToList();
            return _mapper.Map<List<StudentViewModel>>(filteredStudents);
        }

        public async Task<List<StudentViewModel>> SearchStudentsByNameAsync(string name)
        {
            var students = await _repository.GetAllAsync();
            var searchedStudents = students.Where(s => s.Name.Contains(name)).ToList();
            return _mapper.Map<List<StudentViewModel>>(searchedStudents);
        }

        public async Task<StudentViewModel> GetStudentByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            return _mapper.Map<StudentViewModel>(student);
        }

        public async Task AddStudentAsync(StudentViewModel model, IFormFile imageFile)
        {
            string imageUrl = null;

            if (imageFile != null && imageFile.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                imageUrl = $"/images/{imageFile.FileName}";  
            }

            var student = _mapper.Map<Student>(model);
            student.Image = imageUrl;

            await _repository.AddAsync(student);
            await _repository.SaveChangesAsync();
        }
    }
}
