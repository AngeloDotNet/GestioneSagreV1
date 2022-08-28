namespace GestioneSagre.Extensions;
public static class ValidationInternalServices
{
    public static IServiceCollection AddValidationInternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
        });

        // GestioneSagre.Internal.Validators
        services.AddValidatorsFromAssemblyContaining<MailSupportoSenderValidator>();

        return services;
    }
}