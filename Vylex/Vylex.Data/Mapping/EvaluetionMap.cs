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

        builder.Property(c => c.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("int");

        builder.Property(e => e.DateTimeEvaluetion)
               .IsRequired()
               .HasColumnName("DateEvaluetion")
               .HasColumnType("datetime")
               .HasMaxLength(30);

        builder.Property(e => e.StarEvaluetion)
                .IsRequired()
               .HasColumnName("StarEvaluetion")
               .HasColumnType("int")               
               .HasDefaultValue(1);

        builder.Property(e => e.Comment)
               .HasMaxLength(100);

        builder.Property(e => e.StudentId)
               .IsRequired()
               .HasColumnType("int")
               .HasColumnName("StudentId");



        builder.Property(e => e.CourseId)
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("CourseId");


        builder.HasOne(c => c.Student)
               .WithMany(e => e.Evaluetions); ;

        builder.HasOne(c => c.Course)
            .WithMany(e => e.ListEvaluetions);
    }
}
