using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileService.Data.Context
{
    public class ProfileContextFactory : IDesignTimeDbContextFactory<ProfileContext>
    {
        public ProfileContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProfileContext>();
            builder.UseMySql("server=localhost;port=3306;database=QuestionService_ProfileDB;uid=root;password=root;");
            return new ProfileContext(builder.Options);
        }
    }
}
