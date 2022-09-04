using GestioneSagre.Web.Shared.Services.Supporto;
using GestioneSagre.Web.Shared.Services.Versione;
using Microsoft.Extensions.DependencyInjection;

namespace GestioneSagre.Web.Shared.Extensions;

public static class RegisterClientServices
{
    public static IServiceCollection AddRegisterClientServices(this IServiceCollection services)
    {
        // Services TRANSIENT
        services.AddTransient<IConfigurazioneService, ConfigurazioneService>();
        services.AddTransient<IVersioneService, VersioneService>();
        services.AddTransient<ISupportoService, SupportoService>();

        return services;
    }
}