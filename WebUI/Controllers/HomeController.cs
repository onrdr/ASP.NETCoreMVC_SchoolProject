using Entities.Concrete.Identity;
using Entities.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            : base(userManager, signInManager)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AppUser user = await UserManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError(nameof(model.UserName), "User not found");
                return View(model);
            }

            await SignInManager.SignOutAsync();
            Microsoft.AspNetCore.Identity.SignInResult result = await SignInManager.
                PasswordSignInAsync(user, model.Password, model.RememberMe, true);

            if (!result.Succeeded)
            { 
                int fail = await UserManager.GetAccessFailedCountAsync(user);
                ModelState.AddModelError("", $"Login Failed #{fail}");

                if (fail == 3)
                {
                    await UserManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(20)));
                    ModelState.AddModelError("", "Your account has been locked for 20 minutes");
                }
                else
                    ModelState.AddModelError("", "Invalid Username or password");
                return View(model);
            }
            var returnUrl = (string)TempData["ReturnUrl".ToString()];

            if (string.IsNullOrEmpty(returnUrl)) 
                return RedirectToAction("Index", "Member"); 

            return Redirect($"{returnUrl}"); 
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

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