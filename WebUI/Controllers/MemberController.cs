using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class MemberController : BaseController
    {
        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            : base(userManager, signInManager)
        {

        } 
        public IActionResult Index()
        {
            if (CurrentUser.StudentId is not null) 
                return RedirectToAction("Index", "Student"); 

            if (CurrentUser.TeacherId is not null) 
                return RedirectToAction("Index", "Teacher"); 

            return RedirectToAction("Index", "Admin");
        }
    }
}
