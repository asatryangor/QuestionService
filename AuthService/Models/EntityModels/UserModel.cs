using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Models.EntityModels
{
    public class UserModel : BaseEntityModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FacebookId { get; set; }
        public int RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
