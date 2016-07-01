using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Entities.Identity.Entities
{
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
    }
}