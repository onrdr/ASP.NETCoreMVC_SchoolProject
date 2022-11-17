using AutoMapper;
using Business.Abstract;
using Entities.Concrete.Identity;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class MemberController : BaseController
    {
        readonly IStudentService _studentService;
        readonly ITeacherService _teacherService;
        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, 
            IStudentService studentService, ITeacherService teacherService)
            : base(userManager, signInManager, mapper)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }
        public IActionResult Index(AppUser user)
        {
            if (CurrentUser.StudentId is not null)
                return RedirectToAction("Index", "Student");

            if (CurrentUser.TeacherId is not null)
                return RedirectToAction("Index", "Teacher");

            return RedirectToAction("Index", "Admin", user);
        }

        #region Edit Member Info
        public IActionResult Edit()
        {
            AppUser user = CurrentUser;
            var userVm = new MemberVM()
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Picture = user.Picture,
            };
            return View(userVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MemberVM model)
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                var user = CurrentUser;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Picture = model.Picture;

                var result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await SignInManager.SignOutAsync();
                    await SignInManager.SignInAsync(user, true);
                    TempData["update-status"] = "Information Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["update-status"] = "Error Occured While Updating";
                }
            }            
            return View(model);
        }
        #endregion

        #region Delete Member
        public async Task<IActionResult> DeleteMember(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            var result = await UserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                var student = _studentService.GetStudentById((int)user.StudentId);
                _studentService.Delete(student);
                TempData["status"] = "Deleted Successfully";
            }
            return RedirectToAction("Users", "Admin");
        }
        #endregion

        #region Change Password
        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AppUser user = CurrentUser;

            if (user == null)
                return View(model);

            bool exist = await UserManager.CheckPasswordAsync(user, model.PasswordOld);

            if (!exist)
            {
                ModelState.AddModelError("", "Old Password is wrong");
                return View(model);
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(user, model.PasswordOld, model.PasswordNew);

            if (!result.Succeeded)
            {
                AddModelError(result);
                return View(model);
            }

            await UserManager.UpdateSecurityStampAsync(user);
            await SignInManager.SignOutAsync();
            await SignInManager.PasswordSignInAsync(user, model.PasswordNew, true, false);

            ViewBag.success = true;
            return View(model);

        }
        #endregion
    }
}
