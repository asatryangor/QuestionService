using AuthService.Core.Services.CRUDService;
using AuthService.Data.Entities;

namespace AuthService.Core.Services.AuthService
{

    public interface IAuthService : ICrudService<User>
    {
        bool Exists(string username);
        bool CheckPassword(string username, string password);
        User GetByUsername(string username);
        User GetByFacebookId(string facebookId);
    }
}
