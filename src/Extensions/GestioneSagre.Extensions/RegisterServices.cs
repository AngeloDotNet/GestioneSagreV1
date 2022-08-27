namespace GestioneSagre.Core.Customizations.ServiceCollection;

public static class RegisterServices
{
    public static IServiceCollection AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Services TRANSIENT - GestioneSagre.XXX.CommandStack
        services.AddTransient<ICategoriaCommandStackService, CategoriaCommandStackService>();
        services.AddTransient<IFestaCommandStackService, FestaCommandStackService>();

        // Services TRANSIENT - GestioneSagre.XXX.QueryStack
        services.AddTransient<ICategoriaQueryStackService, CategoriaQueryStackService>();
        services.AddTransient<IFestaQueryStackService, FestaQueryStackService>();

        // Services SINGLETON
        services.AddSingleton<IImagePersister, MagickNetImagePersister>();

        return services;
    }
}