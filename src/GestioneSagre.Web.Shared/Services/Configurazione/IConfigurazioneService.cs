namespace GestioneSagre.Web.Shared.Services.Configurazione;

public interface IConfigurazioneService
{
    Task<string> GetPathApplicationAPI();
    Task<string> GetPathInternalAPI();
}
