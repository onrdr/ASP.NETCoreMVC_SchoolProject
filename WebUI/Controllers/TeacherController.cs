using AutoMapper;
using Business.Abstract;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class TeacherController : BaseController
    {
        readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IMapper mapper)
            : base(userManager, signInManager, mapper)
        {
            _teacherService = teacherService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
