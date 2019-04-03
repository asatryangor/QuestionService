using System;
using System.Collections.Generic;
using System.Text;

namespace VoteService.Data.Entities
{
    public class Vote
    {
        public string ProfileId { get; set; }
        public string QuestionId { get; set; }
        public bool Score { get; set; }
    }
}
