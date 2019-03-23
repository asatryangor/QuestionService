using AuthService.Core.Services.CRUDService;
using AuthService.Data.Context;
using AuthService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthService.Core.Services.AuthService
{
    public class AuthService : CrudService<User>, IAuthService
    {
        public AuthService(AuthContext context) : base(context)
        {
        }

        public bool Exists(string login)
        {
            return _context.Users.Any(x => x.Login == login);
        }

        public bool CheckPassword(string login, string password)
        {
            return _context.Users.Any(x => x.Login == login && x.Password == password);
        }

        public User GetByUsername(string login)
        {
            return _context.Users
                           .SingleOrDefault(x => x.Login == login);
        }
    }
}
