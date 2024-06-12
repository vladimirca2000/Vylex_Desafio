using Microsoft.EntityFrameworkCore;

namespace Vylex.Data.Context;

public class ContextBase : DbContext
{
    public ContextBase(DbContextOptions<ContextBase> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
