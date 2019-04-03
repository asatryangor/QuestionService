using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuestionService.Core.Services.TagService;
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
    [Route("api/Tag")]
    public class TagController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;

        public TagController(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetService<IMapper>();
            _tagService = serviceProvider.GetService<ITagService>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new DataResponse<List<TagModel>>(_mapper.Map<List<TagModel>>(_tagService.All)));
            
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var tag = _tagService.All
                                      .SingleOrDefault(x => x.Id == id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(new DataResponse<TagModel>(_mapper.Map<TagModel>(tag)));
        }

        [HttpGet]
        [Route("search")]
        public IActionResult GetQuestions([FromQuery]string tagId)
        {
            var questions = _tagService.All
                                       .Include(x => x.QuestionTags)
                                          .ThenInclude(x => x.Question)
                                       .Where(x => x.Id == tagId)
                                       .Select(x => x.QuestionTags.Select(q => q.Question));
            List<Question> list = new List<Question>();
            foreach(var question in questions)
            {
                foreach(var element in question)
                {
                    list.Add(element);
                }
            }
            if (questions == null)
            {
                return NotFound();
            }
            return Ok(new DataResponse<List<QuestionModel>>(_mapper.Map<List<QuestionModel>>(list)));
        }

        [HttpPost]
        public IActionResult Create([FromBody]TagModel model)
        {
            try
            {
                var tag = _mapper.Map<Tag>(model);
                if (tag != null)
                {
                    return Ok(new DataResponse<TagModel>(_mapper.Map<TagModel>(_tagService.Create(tag))));
                }
                return BadRequest();
            }
            catch
            {
                return Ok(new BaseResponse("Can not create tag", ResponseStatus.InternalException));
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]TagModel model)
        {
            try
            {
                if (model.Id == id)
                {
                    var selectedTag = _tagService.All.SingleOrDefault(x => x.Id == id);
                    if (selectedTag == null)
                    {
                        return NotFound();
                    }
                    return Ok(_mapper.Map<TagModel>(_tagService.Update(selectedTag)));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Ok(new BaseResponse("Can not update tag", ResponseStatus.InternalException));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var tagToRemove = _tagService.All.SingleOrDefault(x => x.Id == id);
                if (tagToRemove == null)
                {
                    return NotFound();
                }
                if (_tagService.Delete(tagToRemove))
                {
                    return Ok(new DataResponse<TagModel>(_mapper.Map<TagModel>(tagToRemove)));
                }
                return BadRequest();
            }
            catch
            {
                return Ok(new BaseResponse("Can not delete tag", ResponseStatus.InternalException));
            }
        }
    }
}