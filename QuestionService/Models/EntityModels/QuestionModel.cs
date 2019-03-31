using System;

namespace QuestionService.Models.EntityModels
{
    public class QuestionModel : BaseEntityModel
    {
        public string Text { get; set; }
        public string UserId { get; set; }
        public int Score { get; set; }
        public DateTime DateTime { get; set; }
    }
}
