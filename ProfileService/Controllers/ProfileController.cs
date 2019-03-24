using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProfileService.Core.Services.ImageService;
using ProfileService.Core.Services.ProfileService;
using System;

namespace ProfileService.Controllers
{
    [Produces("application/json")]
    [Route("api/Profile")]
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IProfileService _profileService;
        
        public ProfileController(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetService<IMapper>();
            _profileService = serviceProvider.GetService<IProfileService>();
            _imageService= serviceProvider.GetService<IImageService>();
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    _profileService.All.Include(x => x.Image);
        //    return 
        //}
    }
}