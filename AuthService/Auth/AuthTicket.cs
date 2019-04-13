using AuthService.Constants;
using AuthService.Data.Entities;
using AuthService.Enums;
using AuthService.Utils.Settings;

namespace AuthService.Auth
{
    public class AuthTicket
    {
        public string Token { get; }
        public string Username { get; }
        public string FacebookId { get; }
        public string Roles { get; set; }

        public AuthTicket(User user, AuthSettings authSettings, AuthType authType)
        {
            if (authType == AuthType.Basic)
            {
                Token = AuthHelper.GenerateToken(user, authSettings, authType);
                Username = user.Login;
                Roles = RoleConfiguration.UserRole;
            }
            else if (authType == AuthType.Facebook)
            {
                Token = AuthHelper.GenerateToken(user, authSettings, authType);
                FacebookId = user.Login;
                Roles = RoleConfiguration.UserRole;
            }
        }
    }
}