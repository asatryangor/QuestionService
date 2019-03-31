using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using QuestionService.Core.Services.QuestionService;
using System;

namespace QuestionService.Controllers
{
    [Produces("application/json")]
    [Route("api/Question")]
    public class QuestionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;
        public QuestionController(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetService<IMapper>();
            _questionService = serviceProvider.GetService<IQuestionService>();
        }
    }
}