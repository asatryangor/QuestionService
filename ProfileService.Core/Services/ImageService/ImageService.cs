using ProfileService.Core.Services.CRUDService;
using ProfileService.Data.Context;
using ProfileService.Data.Entities;

namespace ProfileService.Core.Services.ImageService
{
    public class ImageService : CrudService<Image>, IImageService
    {
        public ImageService(ProfileContext context) : base(context)
        {
        }
    }
}
