namespace GestioneSagre.Internal.Extensions;

public static class ValidationInternalServices
{
    public static IServiceCollection AddValidationInternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
        });

        // GestioneSagre.Versioni.Validators
        services.AddValidatorsFromAssemblyContaining<VersioneCreateValidator>();

        // GestioneSagre.Internal.Validators
        services.AddValidatorsFromAssemblyContaining<MailSupportoSenderValidator>();

        return services;
    }
}