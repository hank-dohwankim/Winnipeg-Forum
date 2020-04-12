using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WinnipegForum.Data.Models;

namespace WinnipegForum.Data
{
    public class DataSeeder
    {
        private ApplicationDbContext _dbContext;

        public DataSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task SeedSuperUser()
        {
            var roleStore = new RoleStore<IdentityRole>(_dbContext);
            var userStore = new UserStore<IdentityUser>(_dbContext);

            var user = new ApplicationUser
            {
                UserName = "Admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                Email = "admin@example.com",
                NormalizedEmail = "admin@example.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            var hashedPassword = hasher.HashPassword(user, "admin!@");
            user.PasswordHash = hashedPassword;
       
            var hasAdminRole = _dbContext.Roles.Any(roles => roles.Name == "Admin");
            if (!hasAdminRole)
            {
               roleStore.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "admin" });
            }

            var hasSuperUser = _dbContext.Users.Any(u => u.NormalizedUserName == user.UserName);
            if (!hasSuperUser)
            {
                userStore.CreateAsync(user);
                userStore.AddToRoleAsync(user, "Admin");
            }

            return _dbContext.SaveChangesAsync();
        }
    }
}
