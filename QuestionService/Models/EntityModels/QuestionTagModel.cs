using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionService.Models.EntityModels
{
    public class QuestionTagModel
    {
        public string QuestionId { get; set; }
        public QuestionModel Question { get; set; }

        public string TagId { get; set; }
        public TagModel Tag { get; set; }
    }
}
