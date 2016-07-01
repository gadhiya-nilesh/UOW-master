using AutoMapper;
using B101Auth.Web.Identity.DTOs;
using Northwind.Entities.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.Entities.AutoMapperConfigurations;

namespace Northwind.Entities.Identity.AutoMappingProfiles
{
    public class UserProfileInfoProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<UserProfileInfo, UserProfileInfoDTO>()
                .IgnoreAllNonExisting();

            Mapper.CreateMap<UserProfileInfoDTO, UserProfileInfo>()
                .IgnoreAllNonExisting();
        }

        public override string ProfileName
        {
            get { return this.GetType().Name; }
        } 
    }
}