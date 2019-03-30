﻿using Microsoft.EntityFrameworkCore;
using QuestionService.Data.Configurations;
using QuestionService.Data.Entities;

namespace QuestionService.Data.Context
{
    public class QuestionContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public QuestionContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        }
    }
}
