using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileService.Models.EntityModels
{
    public class ImageModel : BaseEntityModel
    {
        public string FilePath { get; set; }

        public int ProfileId { get; set; }
        public ProfileModel Profile { get; set; }
    }
}
