using System;
using System.Collections.Generic;
using System.Text;

namespace AuthService.Data.Entities
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
