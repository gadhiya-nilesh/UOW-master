namespace Northwind.Entities.Migrations.Identity
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Northwind.Entities.Identity.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Northwind.Entities.Identity.AuthenticationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(Northwind.Entities.Identity.AuthenticationDbContext context)
        {
            ApplicationUserManager manager = new ApplicationUserManager(new ApplicationUserStore(context));

            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole, int, ApplicationUserRole>(context));

            var user = new ApplicationUser()
            {
                UserName = "superuser@auth.com",
                Email = "superuser@auth.com",
                PhoneNumber = "7208721248",
                UserProfileInfo = new UserProfileInfo
                {
                    Company = "Auth",
                    FirstName = "Super",
                    LastName = "User",
                    Type = "SuperUser",
                    City = "Pune",
                    State = "Maharashtra",
                    Country = "India",
                    Gender = Gender.Male,
                    AltMobileNumber = "0321456987"
                }
            };

            manager.CreateUser(user, "Password@123");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.CreateAsync(new ApplicationRole { Name = "SuperAdmin" });
                roleManager.CreateAsync(new ApplicationRole { Name = "Admin" });
                roleManager.CreateAsync(new ApplicationRole { Name = "User" });
            }

            var adminUser = manager.FindByNameAsync("superuser@auth.com");

            manager.AddToRolesAsync(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
        }
    }
}
