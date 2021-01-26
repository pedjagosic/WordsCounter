using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class TextEntityConfiguration : IEntityTypeConfiguration<TextEntity>
    {
        public void Configure(EntityTypeBuilder<TextEntity> builder)
        {
            builder
                .ToTable("Texts");

            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Text)
                .IsRequired();
        }
    }
}
