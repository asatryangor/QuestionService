using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteService.Models.EntityModels
{
    public class VoteModel
    {
        public string Id { get; set; }
        public string ProfileId { get; set; }
        public string QuestionId { get; set; }
        public bool Score { get; set; }
    }
}
