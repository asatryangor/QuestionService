using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VoteService.Data.Configurations;
using VoteService.Data.Entities;

namespace VoteService.Data.Context
{
    public class VoteContext : DbContext
    {
        public DbSet<Vote> Votes { get; set; }
        public VoteContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new VoteConfiguration());
        }
    }
}
