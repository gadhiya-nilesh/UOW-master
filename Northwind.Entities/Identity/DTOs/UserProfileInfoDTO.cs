using Northwind.Entities.Identity.DTOs;
using Northwind.Entities.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B101Auth.Web.Identity.DTOs
{
    public class UserProfileInfoDTO
    {
        public int Id { get; set; }
        public virtual ApplicationUserDTO ApplicationUser { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string AltMobileNumber { get; set; }
        public virtual string Country { get; set; }
        public virtual string State { get; set; }
        public virtual string City { get; set; }
        public virtual string Address { get; set; }
        public virtual string Type { get; set; }
        public virtual string Company { get; set; }
    }
}