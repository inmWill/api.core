﻿using API.Core.Domain.Enums;
using API.Core.Domain.Models.UserIdentity;
using API.Core.Rest.WebAPI.EditModels;
using API.Core.Rest.WebAPI.ViewModels;
using API.Core.Utils.Automapper.AutoMapper;

namespace API.Core.Rest.WebAPI
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureAutomapperMappings();
        }

        private static void ConfigureAutomapperMappings()
        {
            // Authentication
            AutoMapperConfig.CreateMap<AuthorizedClient, API.Core.Repository.Models.Identity.AuthorizedClient>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Identity.AuthorizedClient, AuthorizedClient>();

            AutoMapperConfig.CreateMap<AppUser, API.Core.Repository.Models.Identity.AppUser>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Identity.AppUser, AppUser>();

            AutoMapperConfig.CreateMap<AppUserEditModel, AppUser>();
            AutoMapperConfig.CreateMap<AppUser, AppUserEditModel>();
           
            AutoMapperConfig.CreateMap<RefreshToken, API.Core.Repository.Models.Identity.RefreshToken>();
            AutoMapperConfig.CreateMap<API.Core.Repository.Models.Identity.RefreshToken, RefreshToken>();


        }
    }
}