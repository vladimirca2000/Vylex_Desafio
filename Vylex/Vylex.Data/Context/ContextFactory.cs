using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Vylex.Data.Context;

public class ContextFactory : IDesignTimeDbContextFactory<ContextBase>
{
    public ContextBase CreateDbContext(string[] args)
    {        
        var connectionString = "Server=localhost;Port=3306;Database=dbVylex;Uid=APPS;Pwd=APPS";
        var optionsBuilder = new DbContextOptionsBuilder<ContextBase>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        return new ContextBase(optionsBuilder.Options);        
    }
}
