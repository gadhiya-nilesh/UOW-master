using AutoMapper;
using Northwind.Entities.Identity.AutoMappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Entities.AutoMapperConfigurations
{
    public class AutoMappingConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AccountUserProfile>();
                x.AddProfile<UserProfileInfoProfile>();
            });
        }
    }
}