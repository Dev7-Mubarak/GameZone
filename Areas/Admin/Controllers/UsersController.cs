using GameZone.Data;
using GameZone.Models;
using GameZone.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Rols.rolAdmin)]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public UsersController(UserManager<AppUser> user, RoleManager<IdentityRole> role)
        {
            _user = user;
            _role = role;
        }

        public async Task<IActionResult> Index()
        {

            var users = _user.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UsreName = user.UserName,
                Roles = _user.GetRolesAsync(user).Result
            });


            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AddRoles(string userId)
        {
            var user = await _user.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _role.Roles.ToListAsync();

            var viewModel = new UserRolesViewModel
            {
                userId = user.Id,
                userName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    roleId = role.Id,
                    roleName = role.Name,
                    useRole = _user.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoles(UserRolesViewModel model)
        {
            var user = await _user.FindByIdAsync(model.userId);

            if (user == null)
            {
                return NotFound();
            }

            var userRole = await _user.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {
                if (userRole.Any(r => r == role.roleName) && !role.useRole)
                {
                    await _user.RemoveFromRoleAsync(user, role.roleName);
                }

                if (!userRole.Any(r => r == role.roleName) && role.useRole)
                {
                    await _user.AddToRoleAsync(user, role.roleName);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string userId)
        {
            var user = await _user.FindByIdAsync(userId);

            var result = await _user.DeleteAsync(user);

            if(result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
