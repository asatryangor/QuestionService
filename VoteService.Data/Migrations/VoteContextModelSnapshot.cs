﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VoteService.Data.Context;

namespace VoteService.Data.Migrations
{
    [DbContext(typeof(VoteContext))]
    partial class VoteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("VoteService.Data.Entities.Vote", b =>
                {
                    b.Property<string>("ProfileId");

                    b.Property<string>("QuestionId");

                    b.Property<bool>("Score");

                    b.HasKey("ProfileId", "QuestionId", "Score");

                    b.ToTable("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
