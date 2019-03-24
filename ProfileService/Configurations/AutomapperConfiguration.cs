using ProfileService.Data.Entities;
using ProfileService.Models.EntityModels;

using A_Profile = AutoMapper.Profile;

namespace ProfileService.Configurations
{
    public class AutomapperConfiguration : A_Profile
    {
        public AutomapperConfiguration()
        {
            BaseEntityMappingConfiguration();
            ProfileModelMappingConfiguration();
        }

        private void BaseEntityMappingConfiguration()
        {
            CreateMap<BaseEntity, BaseEntityModel>();
            CreateMap<BaseEntityModel, BaseEntity>();
        }
        private void ProfileModelMappingConfiguration()
        {
            CreateMap<Profile, ProfileModel>();
            CreateMap<ProfileModel, Profile>();
        }

        private void ImageModelMappingConfiguration()
        {
            CreateMap<Image, ImageModel>();
            CreateMap<ImageModel, Image>();
        }
    }
}
