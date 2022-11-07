using Business.Abstract;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<AppUser> UserManager { get; }
        protected SignInManager<AppUser> SignInManager { get; }
        protected RoleManager<AppRole> RoleManager { get; }
        public BaseController(IEntityService entityService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager = null)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }
        protected AppUser CurrentUser => UserManager.FindByNameAsync(User.Identity.Name).Result;

        public void AddModelError(IdentityResult result)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
    }
}
