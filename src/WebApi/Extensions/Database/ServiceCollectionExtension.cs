using Microsoft.EntityFrameworkCore;
using Provider.Database.Context;

namespace WebApi.Extensions.Database
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configure)
        {
            const string CONNECTION_STRING_NAME = "PsqlDb";

            string connectionString = configure.GetConnectionString(CONNECTION_STRING_NAME) ?? string.Empty;

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(connectionString, opt => opt.CommandTimeout(10));
            });

            return services;
        }
    }
}
