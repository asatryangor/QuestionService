using System;

namespace QuestionService.Models.EntityModels
{
    public class QuestionModel : BaseEntityModel
    {
        public string Text { get; set; }
        public string ProfileId { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
