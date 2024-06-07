using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace arq_backend.Entities.Config
{
    public class MaterialConfig : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(128);
            builder.Property(m => m.Description).HasMaxLength(512);
            builder.Property(m => m.DocumentType).IsRequired().HasMaxLength(32);
        }
    }
}
