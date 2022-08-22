namespace GestioneSagre.Core.Customizations.ServiceCollection;

public static class RegisterServices
{
    public static IServiceCollection AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Services TRANSIENT - GestioneSagre.XXX.CommandStack
        services.AddTransient<ICategoriaCommandStackService, CategoriaCommandStackService>();
        services.AddTransient<VersioneCommandStackService>();

        // Services TRANSIENT - GestioneSagre.XXX.QueryStack
        services.AddTransient<ICategoriaQueryStackService, CategoriaQueryStackService>();
        services.AddTransient<VersioneQueryStackService>();

        // Services SINGLETON
        services.AddSingleton<IInternalQueryStackService, InternalQueryStackService>();
        services.AddSingleton<IImagePersister, MagickNetImagePersister>();

        return services;
    }
}
