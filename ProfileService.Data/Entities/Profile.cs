using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileService.Data.Entities
{
    public class Profile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public Image Image { get; set; }
    }
}
