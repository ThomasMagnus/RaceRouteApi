using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace WebApi.Extensions.Swagger;

public static class SwaggerExtension 
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            var versionProvider = services.BuildServiceProvider()
                .GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in versionProvider.ApiVersionDescriptions)
            {
                string version = description.ApiVersion.ToString();

                OpenApiInfo info = new OpenApiInfo
                {
                    Title = $"RaceRoute - Api v{version}",
                    Version = version,
                };

                if (description.IsDeprecated)
                {
                    info.Description +=
                        " This API version has been deprecated." +
                        " Please use one of the new APIs available from the explorer.";
                }

                options.SwaggerDoc(description.GroupName, info);
            }

            options.OperationFilter<AppResponsesOperationFilter>();

        });

        return services;
    }
}
