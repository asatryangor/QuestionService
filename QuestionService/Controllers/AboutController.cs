using Microsoft.AspNetCore.Mvc;

namespace QuestionService.Controllers
{
    [Produces("application/json")]
    [Route("api/About")]
    public class AboutController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return $"QuestionService {Request.Scheme}://{Request.Host}{Request.PathBase}";
        }
    }
}