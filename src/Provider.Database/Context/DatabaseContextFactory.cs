using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Provider.Database.Context
{
    internal class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        private const string CONNECTION_STRING = "";

        public DatabaseContext CreateDbContext(string[] args)
        {
            string connectionString = Environment.GetEnvironmentVariable(CONNECTION_STRING) ?? string.Empty;

            if (args.Any()) connectionString = args[0];

            Console.WriteLine(connectionString);

            DbContextOptions<DatabaseContext> dbContextOptions = 
                new DbContextOptionsBuilder<DatabaseContext>()
                    .UseNpgsql(connectionString, options => options.CommandTimeout(10))
                    .Options;

            return new DatabaseContext(dbContextOptions);
        }
    }
}
