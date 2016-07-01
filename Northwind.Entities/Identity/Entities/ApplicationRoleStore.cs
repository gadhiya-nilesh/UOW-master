using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Northwind.Entities.Identity.Entities
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole,int, ApplicationUserRole>, IDisposable
    {
        public ApplicationRoleStore(AuthenticationDbContext context)
            : base(context)
        {

        }
    }
}