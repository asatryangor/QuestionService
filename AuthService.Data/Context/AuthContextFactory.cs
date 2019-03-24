using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Runtime.InteropServices;

namespace AuthService.Data.Context
{
    public class AuthContextFactory : IDesignTimeDbContextFactory<AuthContext>
    {
        public AuthContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AuthContext>();
            builder.UseMySql("server=localhost;port=3306;database=QuestionService_AuthDB;uid=root;password=root;");
            return new AuthContext(builder.Options);
        }
    }
}
