using Microsoft.AspNetCore.Identity;

namespace MyBusBookingWebApp.Data
{
    public static class SeedData
    {
        public static async Task EnsureSeed(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Seed roles
            var roles = new[] { "Admin", "User" };
            foreach (var r in roles)
            {
                if (!await roleManager.RoleExistsAsync(r))
                    await roleManager.CreateAsync(new IdentityRole(r));
            }

            // Seed admin user
            var admin = new IdentityUser { UserName = "admin@test.com", Email = "admin@test.com", EmailConfirmed = true };
            if (await userManager.FindByEmailAsync(admin.Email) == null)
            {
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Seed normal user
            var user = new IdentityUser { UserName = "user@test.com", Email = "user@test.com", EmailConfirmed = true };
            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                await userManager.CreateAsync(user, "User@123");
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}