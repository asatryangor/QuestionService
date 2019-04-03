using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionService.Data.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public List<QuestionTag> QuestionTags { get; set; }
    }
}
