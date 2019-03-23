using AuthService.Data.Entities;
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
        }
    }
}
