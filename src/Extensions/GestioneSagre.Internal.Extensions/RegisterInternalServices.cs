namespace GestioneSagre.Internal.Extensions;

public static class RegisterInternalServices
{
    public static IServiceCollection AddRegisterInternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Services TRANSIENT - GestioneSagre.XXX.CommandStack
        services.AddTransient<IVersioneCommandStackService, VersioneCommandStackService>();

        // Services TRANSIENT - GestioneSagre.XXX.QueryStack
        services.AddTransient<IVersioneQueryStackService, VersioneQueryStackService>();

        // Services SINGLETON
        services.AddSingleton<IInternalQueryStackService, InternalQueryStackService>();

        return services;
    }
}
