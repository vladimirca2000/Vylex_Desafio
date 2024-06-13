using Microsoft.EntityFrameworkCore;
using Vylex.Data.Mapping;
using Vylex.Domain.Entities;

namespace Vylex.Data.Context;

public sealed class ContextBase : DbContext
{
    public DbSet<Courses> Course { get; set; }
    public DbSet<Students> Student { get; set; }
    public DbSet<Evaluetions> Evaluetion { get; set; }

    public ContextBase(DbContextOptions<ContextBase> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Courses>(new CourseMap().Configure);
        modelBuilder.Entity<Students>(new StudentMap().Configure);
        modelBuilder.Entity<Evaluetions>(new EvaluetionMap().Configure);

        base.OnModelCreating(modelBuilder);        
    }
}
