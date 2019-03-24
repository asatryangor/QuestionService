using ProfileService.Core.Services.CRUDService;
using ProfileService.Data.Entities;

namespace ProfileService.Core.Services.ProfileService
{
    public interface IProfileService : ICrudService<Profile>
    {
    }
}
