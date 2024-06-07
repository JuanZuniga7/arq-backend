using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace arq_backend.Entities.Config
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(128);
            builder.Property(s => s.Description).HasMaxLength(512);
            builder.HasOne(s => s.Teacher).WithMany(u => u.Subjects).HasForeignKey(s => s.TeacherId);
            builder.HasMany(s => s.Materials).WithOne();
        }
    }
}
