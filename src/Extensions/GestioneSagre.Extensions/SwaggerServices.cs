namespace GestioneSagre.Core.Customizations.ServiceCollection;

public static class SwaggerServices
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration configuration, string ExternalXmlPath)
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
                Description = "API that allows the management of festivals management",

                Contact = new OpenApiContact
                {
                    Name = "Angelo Pirola",
                    Email = "angelo@aepserver.it",
                    Url = new Uri("https://about.me/AngeloPirola"),
                },

                License = new OpenApiLicense
                {
                    Name = "Licenza MIT",
                    Url = new Uri("https://it.wikipedia.org/wiki/Licenza_MIT"),
                }
            });

            options.UseAllOfToExtendReferenceSchemas();
            options.IncludeXmlComments(ExternalXmlPath);
        });

        return services;
    }
}