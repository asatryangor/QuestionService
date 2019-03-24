using ProfileService.Core.Services.CRUDService;
using ProfileService.Data.Context;
using ProfileService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileService.Core.Services.ProfileService
{
    public class ProfileService : CrudService<Profile>, IProfileService
    {
        public ProfileService(ProfileContext context) : base(context)
        {
        }
    }
}
