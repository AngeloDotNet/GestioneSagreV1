namespace GestioneSagre.External.Extensions;

public static class SwaggerExternalServices
{
    public static IServiceCollection AddSwaggerExternalServices(this IServiceCollection services, IConfiguration configuration, string ExternalXmlPath)
    {
        //services.AddAuthorization(options =>
        //{
        //    options.FallbackPolicy = options.DefaultPolicy;
        //});

        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<DefaultResponseOperationFilter>();
            options.OperationFilter<AuthResponseOperationFilter>();

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Gestione Sagre",
                Version = "v1",
            });

            options.UseAllOfToExtendReferenceSchemas();
            options.IncludeXmlComments(ExternalXmlPath);
        });

        return services;
    }
}