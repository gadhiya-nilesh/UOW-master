using Northwind.Entities.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Northwind.Entities.Identity.EntityConfigurations
{
    public class ApplicationUserLoginConfiguration : EntityTypeConfiguration<ApplicationUserLogin>
    {
        public ApplicationUserLoginConfiguration()
        {
            this.HasKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey });
            this.Property(t => t.LoginProvider).IsRequired().HasMaxLength(128);
            this.Property(t => t.ProviderKey).IsRequired().HasMaxLength(128);
            this.Property(t => t.UserId).IsRequired();
            this.ToTable("UserLogin");
        }
    }
}