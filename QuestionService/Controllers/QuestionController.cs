using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using QuestionService.Core.Services.QuestionService;
using QuestionService.Data.Entities;
using QuestionService.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Enums;
using Utils.Models.Responses;

namespace QuestionService.Controllers
{
    [Produces("application/json")]
    [Route("api/Question")]
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;
        public QuestionController(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetService<IMapper>();
            _questionService = serviceProvider.GetService<IQuestionService>();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(new DataResponse<List<QuestionModel>>(_mapper.Map<List<QuestionModel>>(_questionService.All)));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(string id)
        {
            var question = _questionService.All
                                           .SingleOrDefault(x => x.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(new DataResponse<QuestionModel>(_mapper.Map<QuestionModel>(question)));
        }

        [HttpPost]
        public IActionResult Create([FromBody]QuestionModel model)
        {
            try
            {
                var question = _mapper.Map<Question>(model);
                question.CreatedDateTime = DateTime.UtcNow;
                question.Score = 0;
                if (question != null)
                {
                    return Ok(new DataResponse<QuestionModel>(_mapper.Map<QuestionModel>(_questionService.Create(question))));
                }
                return BadRequest();
            }
            catch
            {
                return Ok(new BaseResponse("Can not create question", ResponseStatus.InternalException));
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]QuestionModel model)
        {
            try
            {
                if (model.Id == id)
                {
                    var selectedQuestion = _questionService.All.SingleOrDefault(x => x.Id == id);
                    if (selectedQuestion == null)
                    {
                        return NotFound();
                    }
                    selectedQuestion.ModifiedDateTime = DateTime.UtcNow;
                    selectedQuestion.Text = model.Text;
                    return Ok(_mapper.Map<QuestionModel>(_questionService.Update(selectedQuestion)));

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse("Can not update question", ResponseStatus.InternalException));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var questionToRemove = _questionService.All.SingleOrDefault(x => x.Id == id);
                if (questionToRemove == null)
                {
                    return NotFound();
                }
                if (_questionService.Delete(questionToRemove))
                {
                    return Ok(new DataResponse<QuestionModel>(_mapper.Map<QuestionModel>(questionToRemove)));
                }
                return BadRequest();
            }
            catch
            {
                return Ok(new BaseResponse("Can not delete question", ResponseStatus.InternalException));
            }
        }
    }
}