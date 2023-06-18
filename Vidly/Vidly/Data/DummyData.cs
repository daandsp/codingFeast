using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Data;

namespace IdentityCore.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
                              UserManager<IdentityUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";


            // Initialize standard roles
            string role1 = "CanManageMovies";

            string role2 = "CanManageCustomers";

            string role3 = "CanManageSales";

            string role4 = "CanManagePermissions";

            string password = "P@ssW0rd!";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role1));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role2));
            }
            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role3));
            }
            if (await roleManager.FindByNameAsync(role4) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role4));
            }

            if (await userManager.FindByNameAsync("admin@vidly.com") == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "admin@vidly.com",
                    Email = "admin@vidly.com",
                    PhoneNumber = "6902341234"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                    await userManager.AddToRoleAsync(user, role2);
                    await userManager.AddToRoleAsync(user, role3);
                    await userManager.AddToRoleAsync(user, role4);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("employee@vidly.com") == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "employee@vidly.com",
                    Email = "employee@vidly.com",
                    PhoneNumber = "7788951456"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }
                adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("customer@vidly.com") == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "customer@vidly.com",
                    Email = "customer@vidly.com",
                    PhoneNumber = "6572136821"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                }
            }
        }
    }
}
