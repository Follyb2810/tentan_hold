using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace tenant_api.Models
{
    public class UserRole
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "SuperAdmin", "Admin", "Moderator", "Merchant", "User" };
            foreach (string role in roles)
            {
                var rolesExist = await roleManager.RoleExistsAsync(role);
                if (!rolesExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

    }
}