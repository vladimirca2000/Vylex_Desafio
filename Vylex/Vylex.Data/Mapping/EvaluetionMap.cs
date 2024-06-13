using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vylex.Domain.Entities;

namespace Vylex.Data.Mapping;

public class EvaluetionMap : IEntityTypeConfiguration<Evaluetions>
{
    public void Configure(EntityTypeBuilder<Evaluetions> builder)
    {
        builder.ToTable("Evaluetion");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.DateTimeEvaluetion)
               .IsRequired()
               .HasMaxLength(30);

        builder.Property(e => e.StarEvaluetion)
               .IsRequired();

        builder.Property(e => e.Comment)
               .HasMaxLength(100);

        builder.Property(e => e.StudentId)
               .IsRequired();

        builder.Property(e => e.CourseId)
            .IsRequired();

        builder.HasOne(c => c.Student)
               .WithMany()
               .HasForeignKey(c => c.StudentId);        

        builder.HasOne(c => c.Course)
            .WithMany()
                .HasForeignKey(c => c.CourseId);
    }
}
