using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Enums;
using Entities.Concrete.Identity;
using Entities.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers
{
    public class AdminController : BaseController
    {
        readonly IStudentService _studentService;
        readonly ITeacherService _teacherService;
        public AdminController(IStudentService studentService, ITeacherService teacherService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            : base(null, userManager, signInManager)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Register()
        {
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                Student student = new()
                {
                    StudentNo = model.StudentNo,
                    Name = model.Name,
                    LastName = model.LastName,
                    Birthday = model.BirthDay,
                    Gender = (int)model.Gender,
                    Email = model.Email
                };
                var studentResult = _studentService.Add(student);

                if (studentResult.Success)
                {
                    AppUser user = new()
                    {
                        StudentId = _studentService.GetStudentIdByStudentNo(student.StudentNo),
                        UserName = model.UserName,
                        PasswordHash = model.Password,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber
                    };
                    var result2 = await UserManager.CreateAsync(user, model.Password);
                    if (result2.Succeeded)
                        TempData["success"] = "Student Registered Successfully";
                    return View(model);

                }
                TempData["error"] = studentResult.Message;
            }
            return View(model);
        }
    }
}
