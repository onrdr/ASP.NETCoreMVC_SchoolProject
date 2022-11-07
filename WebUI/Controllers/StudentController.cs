using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Identity;
using Entities.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class StudentController : BaseController
    {
        readonly IStudentService _studentService;
        public StudentController(IStudentService studentService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            : base(studentService, userManager, signInManager)
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
    }
}

