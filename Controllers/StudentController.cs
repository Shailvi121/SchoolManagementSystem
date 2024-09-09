using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Interface;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string className = null, string name = null)
        {
            IEnumerable<StudentViewModel> studentViewModels;

            if (!string.IsNullOrEmpty(className))
            {
                studentViewModels = await _studentService.GetStudentsByClassAsync(className);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                studentViewModels = await _studentService.SearchStudentsByNameAsync(name);
            }
            else
            {
                var students = await _studentService.GetAllAsync();
                studentViewModels = _mapper.Map<List<StudentViewModel>>(students);
            }

            return View(studentViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model, IFormFile imageFile)
        {
                await _studentService.AddStudentAsync(model, imageFile);
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Search(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var studentViewModels = await _studentService.SearchStudentsByNameAsync(name);
                return View("Index", studentViewModels);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
