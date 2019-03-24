using Microsoft.EntityFrameworkCore;
using ProfileService.Data.Configurations;
using ProfileService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileService.Data.Context
{
    public class ProfileContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Image> Images { get; set; }
        public ProfileContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
        }
    }
}
