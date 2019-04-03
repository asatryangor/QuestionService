using QuestionService.Core.Services.CRUDService;
using QuestionService.Data.Context;
using QuestionService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionService.Core.Services.TagService
{
    public class TagService : CrudService<Tag>, ITagService
    {
        public TagService(QuestionContext context) : base(context)
        {
        }
    }
}
