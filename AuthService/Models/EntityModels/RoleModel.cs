using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Models.EntityModels
{
    public class RoleModel : BaseEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
