using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Interface;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var teacherViewModels = await _teacherService.GetAllTeachersAsync();
            return View(teacherViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherViewModel model, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                await _teacherService.AddTeacherAsync(model, imageFile);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
