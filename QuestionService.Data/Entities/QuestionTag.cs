using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionService.Data.Entities
{
    public class QuestionTag
    {
        public string QuestionId { get; set; }
        public Question Question { get; set; }

        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
