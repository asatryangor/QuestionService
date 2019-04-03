using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionService.Data.Entities;

namespace QuestionService.Data.Configurations
{
    public class QuestionTagConfiguration : IEntityTypeConfiguration<QuestionTag>
    {
        public void Configure(EntityTypeBuilder<QuestionTag> builder)
        {
            builder.HasKey(x => new
            {
                x.QuestionId,
                x.TagId
            });

            builder.HasOne(x => x.Question)
                   .WithMany(x => x.QuestionTags)
                   .HasForeignKey(pt => pt.QuestionId);

            builder.HasOne(x => x.Tag)
                   .WithMany(x => x.QuestionTags)
                   .HasForeignKey(x => x.TagId);
        }
    }
}
