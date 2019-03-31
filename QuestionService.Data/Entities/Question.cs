using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionService.Data.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string ProfileId { get; set; }
        public int Score { get; set; }
    }
}
