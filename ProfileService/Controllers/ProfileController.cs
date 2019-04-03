using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProfileService.Core.Services.ImageService;
using ProfileService.Core.Services.ProfileService;
using ProfileService.Data.Entities;
using ProfileService.Models.EntityModels;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utils.Enums;
using Utils.Models.Responses;

using E_Profile = ProfileService.Data.Entities.Profile;
using M_File = System.IO.File;

namespace ProfileService.Controllers
{
    [Produces("application/json")]
    [Route("api/Profile")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IProfileService _profileService;
        private readonly IHostingEnvironment _appEnvironment;

        public ProfileController(IServiceProvider serviceProvider, IHostingEnvironment appEnvironment)
        {
            _mapper = serviceProvider.GetService<IMapper>();
            _profileService = serviceProvider.GetService<IProfileService>();
            _imageService = serviceProvider.GetService<IImageService>();
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        [Route("me")]
        public IActionResult Me()
        {
            var profile = _profileService.All
                                         .Include(x => x.Image)
                                         .SingleOrDefault(x => x.UserId == User.Claims
                                                                               .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if (profile != null)
            {
                return Ok(new DataResponse<ProfileModel>(_mapper.Map<ProfileModel>(profile)));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody]ProfileModel profileModel)
        {
            try
            {
                if (profileModel == null)
                {
                    return BadRequest();
                }
                var profile = _mapper.Map<E_Profile>(profileModel);
                profile.UserId = User.Claims
                                     .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                                     .Value;
                if (profile != null)
                {
                    return Ok(new DataResponse<E_Profile>(_profileService.Create(profile)));
                }
                return BadRequest();
            }
            catch
            {
                return Ok(new BaseResponse("Exception", ResponseStatus.InternalException));
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]ProfileModel profileModel)
        {
            try
            {
                if (id == profileModel.Id)
                {
                    var profile = _mapper.Map<E_Profile>(profileModel);
                    if (profile != null)
                    {
                        return Ok(new DataResponse<ProfileModel>(_mapper.Map<ProfileModel>(_profileService.Update(profile))));
                    }
                }
                return BadRequest();
            }
            catch
            {
                return Ok(new BaseResponse("Can not update profile", ResponseStatus.InternalException));
            }
        }

        [HttpPost("UploadImage/{profileId}")]
        public async Task<IActionResult> UploadImage(string profileId)
        {
            try
            {
                IFormFile file = HttpContext.Request.Form.Files.GetFile("file");
                string fileRoute = Path.Combine(_appEnvironment.ContentRootPath, "Uploads");
                string mimeType = HttpContext.Request.Form.Files.GetFile("file").ContentType;
                string extension = Path.GetExtension(file.FileName);
                string name = Guid.NewGuid() + extension;
                string filePath = Path.Combine("/Uploads", name);

                // Create directory if it does not exist.
                FileInfo dir = new FileInfo(fileRoute);
                dir.Directory?.Create();

                // Basic validation on mime types and file extension
                string[] imageMimetypes = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };
                string[] imageExt = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };

                if (Array.IndexOf(imageMimetypes, mimeType) >= 0 && (Array.IndexOf(imageExt, extension) >= 0))
                {
                    var image = _imageService.All.SingleOrDefault(x => x.ProfileId == profileId);
                    if (image != null && M_File.Exists(_appEnvironment.ContentRootPath + image.FilePath))
                    {
                        M_File.Delete(_appEnvironment.ContentRootPath + image.FilePath);
                        _imageService.Delete(image);
                    }
                    // Copy contents to memory stream.
                    Stream stream = new MemoryStream();
                    file.CopyTo(stream);
                    stream.Position = 0;
                    String serverPath = Path.Combine(fileRoute, name);
                    // Save the file
                    using (FileStream writerFileStream = M_File.Create(serverPath))
                    {
                        await stream.CopyToAsync(writerFileStream);
                        writerFileStream.Dispose();
                    }
                    var fileToUpload = new Image { FilePath = filePath, ProfileId = profileId };
                    _imageService.Create(fileToUpload);
                    // Return the file path as json
                    return Ok(new { Url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Uploads/{name}" });
                }
                return BadRequest(new BaseResponse("The image did not pass the validation"));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new BaseResponse(ex.Message));
            }
            catch
            {
                return Ok(new BaseResponse("Exception", ResponseStatus.InternalException));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var profileToRemove = _profileService.All
                                                 .Include(x => x.Image)
                                                 .SingleOrDefault(x => x.Id == id);
            if (profileToRemove == null)
            {
                return NotFound();
            }
            try
            {
                if (profileToRemove.Image != null && M_File.Exists(_appEnvironment.ContentRootPath + profileToRemove.Image.FilePath))
                {
                    M_File.Delete(_appEnvironment.ContentRootPath + profileToRemove.Image.FilePath);
                }
                if(_profileService.Delete(profileToRemove))
                {
                    return Ok(new DataResponse<ProfileModel>(_mapper.Map<ProfileModel>(profileToRemove)));
                }
                return BadRequest();
            }
            catch (DbUpdateException)
            {
                return Ok(new BaseResponse("Can not delete", ResponseStatus.InternalException));
            }
        }
    }
}