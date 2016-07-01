using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Entities.Identity.Entities
{
    public class UserProfileInfo
    {
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
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

    public enum Gender : int 
    { 
        Male = 1,
        Female = 2
    }
}