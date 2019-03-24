using AuthService.Core.Services.CRUDService;
using AuthService.Data.Context;
using AuthService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthService.Core.Services.RoleService
{
    public class RoleService : CrudService<Role>, IRoleService
    {
        public RoleService(AuthContext context) : base(context)
        {
        }
    }
}
