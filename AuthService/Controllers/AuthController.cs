using AuthService.Auth;
using AuthService.Core.Services.AuthService;
using AuthService.Data.Entities;
using AuthService.Models.Requests;
using AuthService.Utils.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Utils;

namespace AuthService.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        private readonly AuthSettings _authSettings;

        public AuthController(IServiceProvider serviceProvider, IOptions<AuthSettings> authSettingsAccessor)
        {
            _mapper = serviceProvider.GetService<IMapper>();
            _authService = serviceProvider.GetService<IAuthService>();

            _authSettings = authSettingsAccessor.Value;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(AuthRequest request)
        {
            if (!_authService.CheckPassword(request.Login, CryptoHelper.Encrypt(request.Password)))
            {
                return Unauthorized();
            }

            var user = _authService.GetByUsername(request.Login);

            return Ok(CreateTicketResponse(user));
        }



        [NonAction]
        private AuthTicket CreateTicketResponse(User admin)
        {
            var authTicket = new AuthTicket(admin, _authSettings);
            return authTicket;
        }
    }
}