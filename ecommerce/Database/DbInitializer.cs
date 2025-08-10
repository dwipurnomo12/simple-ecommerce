using ecommerce.Models;
using Microsoft.AspNetCore.Identity;

public static class DbInitializer
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new Role { Name = "Admin" });
            await roleManager.CreateAsync(new Role { Name = "Customer" });
        }

        var user = await userManager.FindByEmailAsync("admin@admin.com");
        if (user == null)
        {
            var adminUser = new User
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                Name = "Admin Shop",
                Phone = "081229248179",
                Address = "Bekasi Timur"
            };

            await userManager.CreateAsync(adminUser, "password");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
