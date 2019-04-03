using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionService.Models.EntityModels
{
    public class TagModel : BaseEntityModel
    {
        public string Name { get; set; }
        public List<QuestionTagModel> QuestionTags { get; set; }
    }
}
