using Northwind.Entities.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Northwind.Entities.Identity.EntityConfigurations
{
    public class ApplicationUserRoleConfiguration : EntityTypeConfiguration<ApplicationUserRole>
    {
        public ApplicationUserRoleConfiguration()
        {
            this.ToTable("UserRole");
            this.Property(t => t.UserId);
            this.Property(t => t.RoleId);
            this.HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}