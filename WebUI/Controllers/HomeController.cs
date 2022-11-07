using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc; 

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            : base(null, userManager, signInManager)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
         
        public IActionResult Login()
        { 
            return View();
        }

        public async void Logout()
        {
            await SignInManager.SignOutAsync();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult ContactMe()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}