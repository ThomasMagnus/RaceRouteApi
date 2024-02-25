using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Provider.Database.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    public void Migrate()
    {
        Database.Migrate();
    }

    public IDbContextTransaction Transaction()
    {
        return base.Database.BeginTransaction();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetAssembly(GetType())!
        );

        base.OnModelCreating(modelBuilder);
    }
}
