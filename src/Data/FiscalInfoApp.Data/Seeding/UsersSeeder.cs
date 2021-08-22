namespace FiscalInfoApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FiscalInfoApp.Common;
    using FiscalInfoApp.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Users.Any(x => x.UserName == "user@user.com"))
            {
                var user = new ApplicationUser
                {
                    AccessFailedCount = 0,
                    Email = "user@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    TwoFactorEnabled = false,
                    EmailConfirmed = false,
                    IsDeleted = false,
                    CreatedOn = DateTime.UtcNow,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = true,
                    UserName = "user@user.com",
                    NormalizedUserName = "USER@USER.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEAyRJvTk14g+UUPK1gPTWtN1fVU3vtWaVHqzPmimA15O+w3uPJFiWsGMsc5Ykrpr0w==", // Password = 123456
                };

                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                return;
            }

            if (dbContext.Users.Any(u => u.Email == "admin@admin.com"))
            {
                return;
            }

            var admin = new ApplicationUser
            {
                AccessFailedCount = 0,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEAyRJvTk14g+UUPK1gPTWtN1fVU3vtWaVHqzPmimA15O+w3uPJFiWsGMsc5Ykrpr0w==", // Password = 123456
            };

            admin.Roles.Add(new IdentityUserRole<string>()
            {
                RoleId = dbContext.Roles
                .FirstOrDefault(r => r.Name == GlobalConstants.AdministratorRoleName)?.Id,
            });

            await dbContext.Users.AddAsync(admin);
            await dbContext.SaveChangesAsync();
        }
    }
}
