using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Domain.Coordinates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Provider.Database.CoordinatesManager;
using System.Text.Json.Serialization;
using WebApi.Extensions.Database;
using WebApi.Extensions.Environmets;
using WebApi.Extensions.Swagger;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddEndpointsApiExplorer()
        .AddSwagger()
        .AddHttpContextAccessor()
        .AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters
                .Add(new JsonStringEnumConverter());
        })
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.Converters
                .Add(new StringEnumConverter());
        });

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressMapClientErrors = true;
    });

    builder.Services
        .AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = false;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

    builder.Services.AddDatabase(builder.Configuration);
    builder.Services.AddScoped<ICoordinatesDbManager, CoordinatesDbManager>();
};

var app = builder.Build();
{
    app.UseCors(builder =>
    {
        builder
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment() || app.Environment.IsLocal())
    {
        app.UseSwagger(config =>
        {
            config.PreSerializeFilters.Add((document, request) =>
            {
                if (request.Headers.TryGetValue("X-Forwarded-Path", out var header))
                {
                    document.Servers = new List<OpenApiServer> {
                        new OpenApiServer
                        {
                            Url = $"{header}"
                        }
                    };
                }
            });    
        });

        var versionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwaggerUI(options =>
        {
            foreach (var description in versionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName
                );
            }
        });
    }

    app.MigrateDatabase();

    app.Run();
}
