using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProfileService.Controllers
{
    [Produces("application/json")]
    [Route("api/About")]
    public class AboutController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return $"ProfileService {Request.Scheme}://{Request.Host}{Request.PathBase}";
        }
    }
}