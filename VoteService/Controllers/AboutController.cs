using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VoteService.Controllers
{
    [Produces("application/json")]
    [Route("api/About")]
    public class AboutController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return $"VoteService {Request.Scheme}://{Request.Host}{Request.PathBase}";
        }
    }
}
