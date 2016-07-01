using Northwind.Entities.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Northwind.Entities.Identity.EntityConfigurations
{
    public class ApplicationUserClaimConfiguration : EntityTypeConfiguration<ApplicationUserClaim>
    {
        public ApplicationUserClaimConfiguration()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasColumnName("UserClaimId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.UserId).IsRequired();
            this.Property(t => t.ClaimValue);
            this.Property(t => t.ClaimType);
            this.ToTable("UserClaim");
        }
    }
}