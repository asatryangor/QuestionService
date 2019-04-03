using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VoteService.Data.Context
{
    class VoteContextFactory : IDesignTimeDbContextFactory<VoteContext>
    {
        public VoteContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<VoteContext>();
            builder.UseMySql("server=localhost;port=3306;database=QuestionService_VoteDB;uid=root;password=root;");
            return new VoteContext(builder.Options);
        }
    }
}
