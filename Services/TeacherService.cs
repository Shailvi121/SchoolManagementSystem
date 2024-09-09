using AutoMapper;
using SchoolManagementSystem.Interface;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModel;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Service
{
    public class TeacherService : Service<Teacher>, ITeacherService
    {
        private readonly IRepository<Teacher> _repository;
        private readonly IMapper _mapper;
        private readonly string _imagePath;

        public TeacherService(IRepository<Teacher> repository, IMapper mapper)
            : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TeacherViewModel>> GetAllTeachersAsync()
        {
            var teachers = await _repository.GetAllAsync();
            return _mapper.Map<List<TeacherViewModel>>(teachers);
        }

        public async Task<TeacherViewModel> GetTeacherByIdAsync(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);
            return _mapper.Map<TeacherViewModel>(teacher);
        }

        public async Task AddTeacherAsync(TeacherViewModel model, IFormFile imageFile)
        {
            string imageUrl = null;

            if (imageFile != null && imageFile.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                imageUrl = $"/images/{imageFile.FileName}";  // Save the relative URL
            }

            var teacher = _mapper.Map<Teacher>(model);
            teacher.Image = imageUrl;

            await _repository.AddAsync(teacher);
            await _repository.SaveChangesAsync();
        }



    }
}
