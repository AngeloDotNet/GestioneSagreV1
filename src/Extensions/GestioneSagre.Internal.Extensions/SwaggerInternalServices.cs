namespace GestioneSagre.Internal.Extensions;

public static class SwaggerInternalServices
{
    public static IServiceCollection AddSwaggerInternalServices(this IServiceCollection services, IConfiguration configuration, string ExternalXmlPath)
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