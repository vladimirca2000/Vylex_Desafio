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

        builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int");

        builder.HasIndex(c => c.Email)
               .IsUnique();

        builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(50)")
               .HasMaxLength(50);

        builder.Property(c => c.StudentName)
               .IsRequired()
               .HasColumnName("NameStudent")
               .HasColumnType("varchar(80)")
               .HasMaxLength(50);

        

        
    }
}
