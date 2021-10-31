using Microsoft.OpenApi.Models;

namespace Pomodo.Web.Configuration;

public static class SwashbuckleConfiguration
{
    public const string DefaultVersion = "v1";

    public static IServiceCollection AddSwashbuckle(this IServiceCollection services, OpenApiInfo apiInfo) =>
        services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(x => x.FullName);
            c.DescribeAllParametersInCamelCase();
            c.SwaggerDoc(apiInfo.Version, apiInfo);
            c.EnableAnnotations();
        });

    public static void UseSwashbuckle(this IApplicationBuilder app, string name, string apiVersion = DefaultVersion) =>
        app.UseSwagger()
            .UseSwaggerUI(c =>
                c.SwaggerEndpoint($"/swagger/{apiVersion}/swagger.json", $"{name} {apiVersion.ToUpper()}"));
}