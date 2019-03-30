﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionService.Data.Entities
{
    public class Question : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public int Score { get; set; }
    }
}
