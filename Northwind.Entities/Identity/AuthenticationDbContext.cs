using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Northwind.Entities.Identity.Entities;
using Northwind.Entities.Identity.EntityConfigurations;
using System.Data.Entity.Infrastructure;

namespace Northwind.Entities.Identity
{
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public AuthenticationDbContext()
            : base("NorthwindContext")
        {
        }

        public static AuthenticationDbContext Create()
        {
            return new AuthenticationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ApplicationRoleConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserClaimConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserLoginConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserRoleConfiguration());
            modelBuilder.Configurations.Add(new UserProfileInfoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}