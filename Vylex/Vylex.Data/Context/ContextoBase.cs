using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Vylex.Data.Mapping;
using Vylex.Domain.Entities;

namespace Vylex.Data.Context;

public sealed class ContextoBase : DbContext
{
    public DbSet<Courses> Course { get; set; }
    public DbSet<Students> Student { get; set; }
    public DbSet<Evaluetions> Evaluetion { get; set; }

    public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
    {
        //Database.Migrate();
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Courses>(new CourseMap().Configure);
        //modelBuilder.Entity<Students>(new StudentMap().Configure);
        //modelBuilder.Entity<Evaluetions>(new EvaluetionMap().Configure);

        modelBuilder.ApplyConfiguration(new CourseMap());
        modelBuilder.ApplyConfiguration(new StudentMap());
        modelBuilder.ApplyConfiguration(new EvaluetionMap());

        base.OnModelCreating(modelBuilder);        
    }
}
