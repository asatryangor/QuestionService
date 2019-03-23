using Microsoft.EntityFrameworkCore;
using AuthService.Data.Configurations;
using AuthService.Data.Entities;

namespace AuthService.Data.Context
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AuthContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
