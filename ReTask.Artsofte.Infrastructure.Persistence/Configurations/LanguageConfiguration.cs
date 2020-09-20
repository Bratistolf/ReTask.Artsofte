using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReTask.Artsofte.Domain.Entities;

namespace ReTask.Artsofte.Infrastructure.Persistence.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("languages")
                   .HasKey(lang => lang.Id);

            builder.Property(lang => lang.Id)
                   .HasColumnName("id");

            builder.Property(lang => lang.Name)
                   .HasColumnName("name")
                   .HasMaxLength(64);
        }
    }
}
