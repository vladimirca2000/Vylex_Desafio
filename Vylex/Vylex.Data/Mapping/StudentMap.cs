using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vylex.Domain.Entities;

namespace Vylex.Data.Mapping;

public class StudentMap : IEntityTypeConfiguration<Students>
{
    public void Configure(EntityTypeBuilder<Students> builder)
    {
        builder.ToTable("Student");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.StudentName)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(c => c.Email)
               .IsUnique();

        builder.Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(50);
    }
}
