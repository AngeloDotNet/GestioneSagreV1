namespace GestioneSagre.Web.Shared.Services.Configurazione;

public interface IConfigurazioneService
{
    Task<string> GetApplicationApiFromSettings();
    Task<string> GetInternalApiFromSettings();
    Task<string> GetVersioneFromSettings();
}
