using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfileService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileService.Data.Configurations
{
    class BaseEntityConfiguratiion : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
