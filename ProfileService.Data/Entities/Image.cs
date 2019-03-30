﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileService.Data.Entities
{
    public class Image : BaseEntity
    {
        public string FilePath { get; set; }

        public string ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
