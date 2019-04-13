using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Data.Entities
{
    public class User : BaseEntity
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FacebookId { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
