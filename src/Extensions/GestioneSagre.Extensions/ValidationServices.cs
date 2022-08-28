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

        //GestioneSagre.Feste.Validators
        services.AddValidatorsFromAssemblyContaining<FestaCreateValidator>();

        // GestioneSagre.Prodotti.Validators
        services.AddValidatorsFromAssemblyContaining<ProdottoCreateValidator>();

        return services;
    }
}