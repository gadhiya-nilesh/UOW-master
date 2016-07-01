using Northwind.Entities.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Northwind.Entities.Identity.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).IsRequired().HasColumnName("UserId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Email).HasMaxLength(256);
            this.Property(t => t.UserName).IsRequired().HasMaxLength(256);

            this.ToTable("User");

            //Nav:Claims: User can have 1-(0-*) claims
            this
                .HasMany<ApplicationUserClaim>(x => x.Claims)
                .WithRequired()
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete();

            //Nav:Logins: User can have 1-(0-*) Logins
            this
                .HasMany<ApplicationUserLogin>(x => x.Logins)
                .WithRequired()
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete();

            //Nav:Roles:
            //Interestingly, appears not to be using a *-* Map statement:
            this
                .HasMany<ApplicationUserRole>(x => x.Roles)
                .WithRequired()
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            this
                .HasOptional<UserProfileInfo>(t => t.UserProfileInfo)
                .WithRequired(t => t.ApplicationUser)
                .WillCascadeOnDelete(true);
        }
    }
}