using AuthService.Constants;
using AuthService.Data.Context;
using AuthService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService
{
    public static class Seeder
    {
        public static void EnsureSeedData(this AuthContext context)
        {
            context.SeedSettings();
        }

        private static void SeedSettings(this AuthContext context)
        {
            if (!context.Roles.Any(x => x.Name == RoleConfiguration.UserRole))
            {
                context.Roles.Add(new Role
                {
                    Name = RoleConfiguration.UserRole
                });
            }
            if (!context.Roles.Any(x => x.Name == RoleConfiguration.AdminRole))
            {
                context.Roles.Add(new Role
                {
                    Name = RoleConfiguration.AdminRole
                });
            }
            
            context.SaveChanges();
        }
    }
}
