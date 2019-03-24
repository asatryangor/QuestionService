using AuthService.Constants;
using AuthService.Data.Entities;
using AuthService.Utils.Settings;

namespace AuthService.Auth
{
    public class AuthTicket
    {
        public string Token { get; }
        public string Username { get; }
        public string Roles { get; set; }

        public AuthTicket(User user, AuthSettings authSettings)
        {
            Token = AuthHelper.GenerateToken(user, authSettings);
            Username = user.Login;
            Roles = RoleConfiguration.UserRole;
        }
    }
}