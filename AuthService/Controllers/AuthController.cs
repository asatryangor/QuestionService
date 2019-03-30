using AuthService.Auth;
using AuthService.Constants;
using AuthService.Core.Services.AuthService;
using AuthService.Core.Services.RoleService;
using AuthService.Data.Entities;
using AuthService.Models.EntityModels;
using AuthService.Models.Requests;
using AuthService.Utils.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using Utils;
using Utils.Enums;
using Utils.Models.Responses;

namespace AuthService.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;

        private readonly AuthSettings _authSettings;

        public AuthController(IServiceProvider serviceProvider, IOptions<AuthSettings> authSettingsAccessor)
        {
            _mapper = serviceProvider.GetService<IMapper>();
            _authService = serviceProvider.GetService<IAuthService>();
            _roleService = serviceProvider.GetService<IRoleService>();

            _authSettings = authSettingsAccessor.Value;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody]AuthRequest request)
        {
            if (!_authService.CheckPassword(request.Login, CryptoHelper.Encrypt(request.Password)))
            {
                return Unauthorized();
            }

            var user = _authService.GetByUsername(request.Login);

            return Ok(CreateTicketResponse(user));
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]RegisterUserRequest request)
        {
            if (_authService.GetByUsername(request.Login) == null)
            {
                if (request.Password == request.ConfirmPassword)
                {
                    Role role = _roleService.All.SingleOrDefault(x => x.Name == RoleConfiguration.UserRole);
                    if (role == null)
                    {
                        return Ok(new BaseResponse("Role does not found", ResponseStatus.InternalException));
                    }
                    var user = _authService.Create(new User()
                    {
                        Login = request.Login,
                        Password = CryptoHelper.Encrypt(request.Password),
                        RoleId = role.Id
                    });
                    return Ok(CreateTicketResponse(user));
                }
                else
                {
                    return Ok(new BaseResponse("Password mismatch", ResponseStatus.PasswordMismatch));
                }
            }
            return Ok(new BaseResponse("Username already exists", ResponseStatus.AlreadyExists));
        }

        [HttpPut]
        [Route("ChangePassword")]
        [Authorize]
        public IActionResult ChangePassword([FromBody]ChangePasswordRequest request)
        {
            var user = _authService.All.SingleOrDefault(x => x.Id == request.Id);
            if (user != null)
            {
                if (user.Password == CryptoHelper.Encrypt(request.Password))
                {
                    if (request.NewPassword == request.ConfirmNewPassword)
                    {
                        user.Password = CryptoHelper.Encrypt(request.NewPassword);
                        var updatedUser = _authService.Update(user);
                        return Ok(new DataResponse<UserWithoutPasswordModel>(_mapper.Map<UserWithoutPasswordModel>(user)));
                    }
                    else
                    {
                        return Ok(new BaseResponse("Password mismatch", ResponseStatus.PasswordMismatch));
                    }
                }
                return Ok(new BaseResponse("Incorrect password", ResponseStatus.IncorrectPassword));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromBody]string id)
        {
            var user = _authService.All.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                try
                {
                    _authService.Delete(user);
                    return Ok(new BaseResponse());
                }
                catch
                {
                    return Ok(new BaseResponse("Can not delete profile", ResponseStatus.InternalException));
                }
            }
            return NotFound();
        }

        [NonAction]
        private AuthTicket CreateTicketResponse(User user)
        {
            var authTicket = new AuthTicket(user, _authSettings);
            return authTicket;
        }
    }
}