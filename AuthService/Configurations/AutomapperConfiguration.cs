﻿using AuthService.Data.Entities;
using AuthService.Models.EntityModels;
using AutoMapper;

namespace AuthService.Configurations
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            BaseEntityMappingConfiguration();
            UserModelMappingConfiguration();
            RoleModelMappingConfiguration();
        }

        private void BaseEntityMappingConfiguration()
        {
            CreateMap<BaseEntity, BaseEntityModel>();
            CreateMap<BaseEntityModel, BaseEntity>();
        }
        private void UserModelMappingConfiguration()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<User, UserWithoutPasswordModel>();
            CreateMap<UserWithoutPasswordModel, User>();
        }

        private void RoleModelMappingConfiguration()
        {
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();
        }
    }
}
