using Northwind.Entities.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Northwind.Entities.Identity.EntityConfigurations
{
    public class UserProfileInfoConfiguration : EntityTypeConfiguration<UserProfileInfo>
    {
        public UserProfileInfoConfiguration()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.FirstName).HasMaxLength(256);
            this.Property(t => t.LastName).HasMaxLength(256);
            this.Property(t => t.Company).HasMaxLength(256);
            this.Property(t => t.Type).HasMaxLength(256);
            this.ToTable("UserProfileInfo");
        }
    }
}