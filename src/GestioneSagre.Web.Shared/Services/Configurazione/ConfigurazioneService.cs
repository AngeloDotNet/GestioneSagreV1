namespace GestioneSagre.Web.Shared.Services.Configurazione;

public class ConfigurazioneService : IConfigurazioneService
{
    public Task<string> GetPathApplicationAPI()
    {
        var pathWeb = "localhost:5001";

        return Task.FromResult(pathWeb);
    }

    public Task<string> GetPathInternalAPI()
    {
        var pathWeb = "localhost:44360";

        return Task.FromResult(pathWeb);
    }
}