using AutoMapper;
using Business.Abstract;
using Entities.Concrete.Identity;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Student, Admin")]
    public class StudentController : BaseController
    {
        readonly IStudentService _studentService;
        public StudentController(IStudentService studentService, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IMapper mapper)
            : base(userManager, signInManager, mapper)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            StudentInformationVM model = new()
            {
                AppUser = CurrentUser,
                Student = _studentService.GetStudentById((int)CurrentUser.StudentId)
            };
            return View(model);
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult ExamResults()
        {
            return View();
        }
         
        public IActionResult Details(int id)
        {
            var student = _studentService.GetStudentById(id);
            return View(student);
        }
    }
}

