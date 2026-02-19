using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PerfumeStore.DAL.Contexts;
using PerfumeStore.DAL.Models;
using PerfumeStore.DAL.Models.Enums;

namespace PerfumeStore.DAL.DataSeed
{
    public class DbSeeder
    {
        private readonly PerfumeStoreDbContext Context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbSeeder(PerfumeStoreDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.Context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedRolesAndAdmin()
        {
            // Seed Roles
            string[] roleNames = { "Admin", "Accounting", "Sales" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Ensure at least one branch exists
            if (!await Context.Branches.AnyAsync())
            {
                var defaultBranch = new Branch
                {
                    Name = "Main Branch",
                    Address = "Default Address",
                    Phone = "000-000-0000",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };
                Context.Branches.Add(defaultBranch);
                await Context.SaveChangesAsync();
            }

            // Get the first branch
            var firstBranch = await Context.Branches.FirstAsync();

            // Seed default admin user
            var adminEmail = "admin@perfumestore.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    address = "Defult address",
                    FullName = "System Administrator",
                    EmailConfirmed = true,
                    BranchId = 1, // Use actual branch ID
                    IsActive = true,
                };

                var result = await userManager.CreateAsync(admin, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
