using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfileService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileService.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.FilePath);

            builder.HasOne(x => x.Profile)
                   .WithOne(x => x.Image)
                   .HasForeignKey<Image>(x => x.ProfileId);
        }
    }
}
