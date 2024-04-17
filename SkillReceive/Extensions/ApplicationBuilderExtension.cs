using Microsoft.AspNetCore.Identity;
using SkillReceive.Infrastructure.Data.Models;
using static SkillReceive.Core.Constants.RoleConstants;

namespace SkillReceive.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task CreateAdminRole(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
            {
                var role = new IdentityRole(AdminRole);
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync("admin@mail.com");

                if (admin != null) 
                {
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            }
        }
    }
}
