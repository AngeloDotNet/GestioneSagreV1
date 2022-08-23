using FluentValidation;
using FluentValidation.AspNetCore;
using GestioneSagre.Categorie.Validators;
using GestioneSagre.Internal.Validators.EmailSender;
using GestioneSagre.Versioni.Validators.Versione;

namespace GestioneSagre.Extensions;

public static class ValidationServices
{
    public static IServiceCollection AddValidationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
        });

        //GestioneSagre.Categorie.Validators
        services.AddValidatorsFromAssemblyContaining<CategoriaCreateValidator>();
        // GestioneSagre.Versioni.Validators
        services.AddValidatorsFromAssemblyContaining<VersioneCreateValidator>();
        // GestioneSagre.Internal.Validators
        services.AddValidatorsFromAssemblyContaining<MailSupportoSenderValidator>();

        return services;
    }
}
