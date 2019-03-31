using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionService.Data.Entities;

namespace QuestionService.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(x => x.Text);
            builder.Property(x => x.CreatedDateTime);
            builder.Property(x => x.ModifiedDateTime);
            builder.Property(x => x.Score);
            builder.Property(x => x.ProfileId);
        }
    }
}
