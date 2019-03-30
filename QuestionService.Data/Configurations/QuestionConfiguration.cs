﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionService.Data.Entities;

namespace QuestionService.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(x => x.DateTime);
            builder.Property(x => x.Score);
            builder.Property(x => x.UserId);
        }
    }
}
