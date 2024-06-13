using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vylex.Domain.Entities;

namespace Vylex.Data.Mapping;

public class CourseMap : IEntityTypeConfiguration<Courses>
{
    public void Configure(EntityTypeBuilder<Courses> builder)
    {
        builder.ToTable("Course");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("int");

        builder.HasIndex(c => c.CourseName)
            .IsUnique();

        builder.Property(c => c.CourseName)
            .IsRequired()
            .HasColumnName("CourseName")            
            .HasColumnType("varchar(30)")
            .HasMaxLength(30);

        builder.Property(c => c.Description)
            .HasColumnName("Description")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);
    }
}
