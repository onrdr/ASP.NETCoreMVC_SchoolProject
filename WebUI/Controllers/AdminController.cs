using Business.Abstract; 
using Entities.Concrete;
using Entities.Concrete.Enums;
using Entities.Concrete.Identity;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : BaseController
    {
        readonly IStudentService _studentService;
        readonly ITeacherService _teacherService;        
        public AdminController(IStudentService studentService, ITeacherService teacherService, 
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
            : base(userManager, signInManager, roleManager)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            AppUser user = CurrentUser;
            AdminVM admin = new()
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Picture = user.Picture,
            };
            return View(admin);
        }

        #region Student Registration
        public IActionResult RegisterNewStudent()
        {
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewStudent(StudentRegisterVM model)
        {
            if (ModelState.IsValid)
            {
                Student student = new()
                {
                    StudentNo = model.StudentNo,
                    Name = model.Name,
                    LastName = model.LastName,
                    Birthday = model.BirthDay,
                    Gender = model.Gender,
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
                    return RedirectToAction("Index");
                }
                ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
                TempData["error"] = studentResult.Message;
            }
            return View(model);
        }
        #endregion

        #region Admin Registration
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(AdminVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    UserName = model.UserName,
                    PasswordHash = model.Password,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Picture = model.Picture
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    TempData["success"] = "Admin Registered Successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Admin registeration failed. Please contact administration";
            return View(model);
        }
        #endregion

        #region Create Role
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleVM model)
        {
            var role = new AppRole
            {
                Name = model.Name
            };
            IdentityResult result = await RoleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                TempData["message"] = "Created Successfully";
                return RedirectToAction("Roles");
            }
            TempData["message"] = "An Error Occured while Deleting the Role";
            AddModelError(result);
            return View();
        }
        #endregion

        #region Role List
        public IActionResult Roles()
        {
            return View(RoleManager.Roles.ToList());
        }
        #endregion     

        #region Edit Role
        public async Task<IActionResult> RoleEdit(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);

            RoleVM roleVM = new()
            {
                Id= id,
                Name = role.Name,
            };
            return View(roleVM);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleVM model)
        {
            AppRole role = await RoleManager.FindByIdAsync(model.Id);

            if (role != null)
            {
                role.Name = model.Name;
                var result = await RoleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    TempData["message"] = "Updated Successfully";
                    return RedirectToAction(nameof(Roles));
                }
                AddModelError(result);
                TempData["message"] = "An Error Occured while Updating the Role";
            }
            return RedirectToAction(nameof(Roles));
        }
        #endregion

        #region Delete Role
        public async Task<IActionResult> RoleDelete(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);

            if (role != null)
            {
                var result = await RoleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    TempData["message"] = "Deleted Successfully";
                    return RedirectToAction(nameof(Roles));
                }
                TempData["message"] = "An Error Occured while Deleting the Role";
            }
            return RedirectToAction(nameof(Roles));
        }
        #endregion

        #region Assign Role
        public async Task<IActionResult> RoleAssign(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            ViewBag.userName = user.UserName;
            TempData["Id"] = id;

            var roles = await RoleManager.Roles.ToListAsync();
            var userRoles = await UserManager.GetRolesAsync(user);
            var roleAssignViewModels = new List<RoleAssignVM>();

            foreach (var role in roles)
            {
                var r = new RoleAssignVM
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    Exist = userRoles.Contains(role.Name)
                };
                roleAssignViewModels.Add(r);
            }
            return View(roleAssignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignVM> model)
        {
            var user = await UserManager.FindByIdAsync(TempData["Id"].ToString());
            foreach (var item in model)
            {
                if (item.Exist)
                {
                    await UserManager.AddToRoleAsync(user, item.RoleName);
                    TempData["status"] = "Updated Successfully";
                    continue;
                }
                await UserManager.RemoveFromRoleAsync(user, item.RoleName);
                TempData["status"] = "Updated Successfully";
            }
            return RedirectToAction("Users");
        }
        #endregion

        #region User List
        public IActionResult Users()
        {
            return View(UserManager.Users.ToList());
        }
        #endregion
    }
}
