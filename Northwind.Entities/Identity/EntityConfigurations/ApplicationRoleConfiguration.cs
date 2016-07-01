using Northwind.Entities.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Northwind.Entities.Identity.EntityConfigurations
{
    public class ApplicationRoleConfiguration : EntityTypeConfiguration<ApplicationRole>
    {
        public ApplicationRoleConfiguration()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).IsRequired().HasColumnName("RoleId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name).IsRequired().HasMaxLength(256);
            this.ToTable("Role");
            this
                .HasMany(x => x.Users)
                .WithRequired()
                .HasForeignKey(x => x.RoleId);
        }
    }
}