using BSATroop829.Models;
using BSATroop829.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BSATroop829.Controllers
{
    [Authorize(Roles = "Admin,Scoutmaster,Committee Member")]
    public class UserRolesController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly LogService _logService;
        public UserRolesController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, LogService logService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logService = logService;
        }
        public async Task<IActionResult> Index(string userId)
        {
            var viewModel = new List<UserRolesViewModel>();
            var user = await _userManager.FindByIdAsync(userId);
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                viewModel.Add(userRolesViewModel);
            }
            var model = new ManageUserRolesViewModel()
            {
                UserId = userId,
                UserRoles = viewModel,
                UserName = user.UserName
            };
            return View(model);
        }
        public async Task<IActionResult> Update(string id, ManageUserRolesViewModel model)
        {
            
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var adminRoles = model.UserRoles.Where(x => x.Selected).Select(x => x.RoleName == "Admin" || x.RoleName == "SuperAdmin");
            if (!User.IsInRole("Admin") || !User.IsInRole("SuperAdmin") && adminRoles.Any())
            {
                ModelState.AddModelError("", "You cannot assign Admin roles to another user.");
                return View("Index", model);
            }
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            result = await _userManager.AddToRolesAsync(user, model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
            var currentUser = await _userManager.GetUserAsync(User);
            await _signInManager.RefreshSignInAsync(currentUser);
            _logService.Log(User.Identity.Name, "Updated the UserRoles for " + user.UserName + " to " + string.Join(",", model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName)));
            return RedirectToAction("Index", new { userId = id });
        }
    }
}
