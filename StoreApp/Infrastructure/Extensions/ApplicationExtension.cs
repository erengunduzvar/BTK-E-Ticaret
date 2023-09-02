using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder application)
        {
            RepositoryContext context = application
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public static void ConfigureLocalization(this WebApplication application)
        {
            application.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                .AddSupportedUICultures("tr-TR")
                .SetDefaultCulture("tr-TR");
            });
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder application)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Faruk123";

            //userManager
            UserManager<IdentityUser> userManager = application
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();


            //RoleManager
            RoleManager<IdentityRole> roleManager = application
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();
            //Asenkron ifadeler apilerde tekrar edilmeli !
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser()
                {
                    Email = "gunduzvareren@gmail.com",
                    PhoneNumber = "5550579377",
                    UserName = adminUser,
                    EmailConfirmed = true,
                };

                var result = await userManager.CreateAsync(user);

                if (!result.Succeeded)
                    throw new Exception("Admin user couldnt create");

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                        .Roles
                        .Select(r => r.Name)
                        .ToList()
                    );

                if(!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role definition");
                }
            }
        }
    }
}
