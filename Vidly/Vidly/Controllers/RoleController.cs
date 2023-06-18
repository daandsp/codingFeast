using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Vidly.Models;

namespace Identity.Controllers
{
    [Authorize(Roles = RoleName.CanManagePermissions)]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;
        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        }

        public ViewResult Index() => View(userManager.Users);

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }



        // Other methods
        public async Task<IActionResult> Update (string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            List<IdentityRole> members = new List<IdentityRole>();
            List<IdentityRole> nonMembers = new List<IdentityRole>();
            foreach (IdentityRole roles in roleManager.Roles)
            {
                var list = await userManager.IsInRoleAsync(user, roles.Name) ? members : nonMembers;
                list.Add(roles);
            }
            return View(new RoleEdit
            {
                User = user,
                Members = members,
                NonMembers = nonMembers
            });
        }


        [HttpPost]
        public async Task<IActionResult> Update (RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string roleId in model.AddRole ?? new string[] { })
                {
                    IdentityRole role = await roleManager.FindByIdAsync(roleId);

                    var userId = model.UserId;
                    IdentityUser user = await userManager.FindByIdAsync(userId);
                    if (role != null)
                    {
                        result = await userManager.AddToRoleAsync(user, role.NormalizedName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string roleId in model.DeleteRole ?? new string[] { })
                {
                    IdentityRole role = await roleManager.FindByIdAsync(roleId);

                    var userId = model.UserId;
                    IdentityUser user = await userManager.FindByIdAsync(userId);
                    if (role != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, role.NormalizedName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Update));
            else
                return await Update(model.UserId);
        }
    }
}
