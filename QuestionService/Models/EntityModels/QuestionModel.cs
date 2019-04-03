using System;
using System.Collections.Generic;

namespace QuestionService.Models.EntityModels
{
    public class QuestionModel : BaseEntityModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ProfileId { get; set; }
        public int Score { get; set; }

        public List<QuestionTagModel> QuestionTags { get; set; }
    }
}
