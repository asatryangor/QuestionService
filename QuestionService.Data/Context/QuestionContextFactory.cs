using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QuestionService.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileService.Data.Context
{
    public class ProfileContextFactory : IDesignTimeDbContextFactory<QuestionContext>
    {
        public QuestionContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<QuestionContext>();
            builder.UseMySql("server=localhost;port=3306;database=QuestionService_QuestionDB;uid=root;password=root;");
            return new QuestionContext(builder.Options);
        }
    }
}
